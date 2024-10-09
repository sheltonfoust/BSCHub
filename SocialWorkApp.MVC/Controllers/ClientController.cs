using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository clientRepository;
        public ClientController(IClientRepository clientRepository) 
        {
            this.clientRepository = clientRepository;
        }
        public IActionResult List()
        { 
            var viewModel = new ClientListViewModel(clientRepository.ListClients());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            clientRepository.Add(client);
            return CreatedAtAction("Client", client);
        }
    }
}
