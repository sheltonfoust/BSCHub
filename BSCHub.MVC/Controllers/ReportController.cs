using Microsoft.AspNetCore.Mvc;
using BSCHub.Application;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.MVC.ViewModels;
using BSCHub.Domain.Dates;

namespace BSCHub.MVC.Controllers
{
    public class ReportController : Controller
    {
        private IReportRepository _reportRepository;
        private IConsultantRepository _providerRepository;
        public ReportController(IReportRepository reportRepository, IConsultantRepository providerRepository)
        {
            _reportRepository = reportRepository;
            _providerRepository = providerRepository;
        }

        public IActionResult List(int consultantId)
        {
            var consultant = _providerRepository.GetConsultant(consultantId);
            if (consultant == null)
                return NotFound();
            var viewModel = new ReportListViewModel(consultant, _reportRepository
                .ListReportsByConsultant(consultant.UserId));

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MarkAsComplete(int yearId, ReportType type, int providerId)
        {
            _reportRepository.SetCompleted(yearId, type, DateHelper.GetToday());
            return RedirectToAction("List", new {providerId = providerId});
        }

        [HttpPost]
        public IActionResult MarkAsNotComplete(int yearId, ReportType type, int providerId)
        {
            _reportRepository.SetNotCompleted(yearId, type);
            _reportRepository.SetNotReviewed(yearId, type);
            return RedirectToAction("List", new { providerId = providerId });

        }
    }
}
