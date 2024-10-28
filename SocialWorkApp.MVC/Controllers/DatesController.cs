using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.DataAccess;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.MVC.ViewModels;
namespace SocialWorkApp.MVC.Controllers
{
    public class DatesController : Controller
    {
        private IClientRepository _clientRepository;
        private IDateRepository _dateRepository;
        public DatesController(IDateRepository dateRepository, IClientRepository clientRepository)
        {
            _dateRepository = dateRepository;
            _clientRepository = clientRepository;
        }


        public IActionResult List(int clientId)
        {
            var client = _clientRepository.GetClient(clientId);
            if (client == null)
            {
                return NotFound();
            }
            var years = _dateRepository.GetISPYears(clientId);
            if (years == null)
            {
                return NotFound();
            }
            var viewModel = new DatesListViewModel(client, years);
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult AddYear(int clientId, DateOnly newYearStart)
        {
            _dateRepository.AddYear(clientId, newYearStart);
            return RedirectToAction("List", new {clientId = clientId});
        }

    }
}
