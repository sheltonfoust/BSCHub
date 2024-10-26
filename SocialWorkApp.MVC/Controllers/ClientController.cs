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
            ViewBag.ShowModal = false;
            return View(GetListViewModel());
        }

        private ClientListViewModel GetListViewModel(bool showModal = false)
        {
            return new ClientListViewModel(
               _clientRepository.ListClients().ToList(),
               _providerRepository.ListProviders().Select(p => new SelectListItem
               {
                   Value = p.ProviderId.ToString(),
                   Text = p.FirstName + " " + p.LastName
               }).ToList(),
               showModal);
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientRepository.Add(client);
                ModelState.Clear();


            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateClient(Client client, int clientId)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = clientId;
                _clientRepository.Update(client);
                ModelState.Clear();


            }

            return NoContent();
        }
        public IActionResult DeleteClient(int clientId)
        {

            _clientRepository.Delete(clientId);
            return NoContent();
       
            
        }
    }
}
