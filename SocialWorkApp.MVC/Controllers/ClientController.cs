using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;

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
            var clients = clientRepository.ListClients();
            return View(clients);
        }
    }
}
