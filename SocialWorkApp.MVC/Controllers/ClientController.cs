using Microsoft.AspNetCore.Components.Web.Virtualization;
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
            var viewModel = new ClientListViewModel(
                _clientRepository.ListClients().ToList(),
                _providerRepository.ListProviders().Select(p => new SelectListItem
                {
                    Value = p.ProviderId.ToString(),
                    Text = p.FirstName + " " + p.LastName
                }).ToList());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            _clientRepository.Add(client);
            return RedirectToAction("List");
        }
    }
}
