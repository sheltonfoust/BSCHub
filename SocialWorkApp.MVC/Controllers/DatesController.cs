using Microsoft.AspNetCore.Mvc;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.DataAccess;
using BSCHub.Domain.Clients;
using BSCHub.MVC.ViewModels;
namespace BSCHub.MVC.Controllers
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
            var client = _clientRepository.GetClient(clientId);
            if (client == null)
                return StatusCode(500);
            _dateRepository.AddYear(clientId, newYearStart);
            return RedirectToAction("List", new {clientId = clientId});
        }

        [HttpPost]
        public IActionResult DeleteYear(int ISP_YearId, int clientId)
        {

            if (ModelState.IsValid)
            {
                _dateRepository.DeleteYear(ISP_YearId);

                return RedirectToAction("List", new { clientId = clientId });

            }
            return NoContent();
        }


        [HttpPost]
        public IActionResult UpdateYear(DateOnly newYearStart, int ISP_YearId, int clientId)
        {
            if (ModelState.IsValid)
            {
                _dateRepository.UpdateYear(newYearStart, ISP_YearId);
                ModelState.Clear();
                return RedirectToAction("List", new { clientId = clientId });

            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult SetMeetingDate(DateOnly meetingDate, int ISP_YearId, int clientId)
        {
            if (ModelState.IsValid)
            {
                _dateRepository.UpdateMeetingDate(meetingDate, ISP_YearId);
                ModelState.Clear();
                return RedirectToAction("List", new { clientId = clientId });

            }

            return NoContent();
        }
    }
}
