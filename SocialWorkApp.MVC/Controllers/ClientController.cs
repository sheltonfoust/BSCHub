using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProviderRepository _providerRepository;
        public ClientController(IClientRepository clientRepository, IProviderRepository providerRepository) 
        {
            this._clientRepository = clientRepository;
            this._providerRepository = providerRepository;
        }
        public IActionResult List()
        {
            return View(GetListViewModel());
        }

        public IActionResult Edit(int clientId)
        {
            ViewBag.Providers = _providerRepository.ListProviders().Select(p => new SelectListItem
            {
                Value = p.ProviderId.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList();
            var client = _clientRepository.GetClient(clientId);
            if (client == null)
                return NotFound();
            return View(client);
        }

        [HttpPost]
        public IActionResult Update(Client client, int clientId)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = clientId;
                _clientRepository.Update(client);
                ModelState.Clear();
                return RedirectToAction("List");
            }
            return NoContent();
        }


        public IActionResult Add()
        {
            ViewBag.Providers = _providerRepository.ListProviders().Select(p => new SelectListItem
            {
                Value = p.ProviderId.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList();

            var newClient = new Client() 
            { 
                ISP_YearStartDate = DateOnly.FromDateTime(DateTime.Now) 
            };

            return View(newClient);
        }



        [HttpPost]
        public IActionResult Add(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientRepository.Add(client);
                ModelState.Clear();

                return RedirectToAction("List");


            }
            return NoContent();
        }

       
        public IActionResult DeleteClient(int clientId)
        {


            if (ModelState.IsValid)
            {
                _clientRepository.Delete(clientId);

                return RedirectToAction("List");

            }
            return NoContent();
        }

        private ClientListViewModel GetListViewModel()
        {
            return new ClientListViewModel(
               _clientRepository.ListClients().ToList(),
               _providerRepository.ListProviders().Select(p => new SelectListItem
               {
                   Value = p.ProviderId.ToString(),
                   Text = p.FirstName + " " + p.LastName
               }).ToList());
        }
    }
}
