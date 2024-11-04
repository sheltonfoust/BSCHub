using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Controllers
{
    public class ReportController : Controller
    {
        private IReportRepository _reportRepository;
        private IProviderRepository _providerRepository;
        public ReportController(IReportRepository reportRepository, IProviderRepository providerRepository)
        {
            _reportRepository = reportRepository;
            _providerRepository = providerRepository;
        }

        public IActionResult List()
        {
            var provider = _providerRepository.GetProvider(1);
            if (provider == null)
                return NotFound();
            var viewModel = new ReportListViewModel(provider, _reportRepository
                .ListReportsByProvider(provider.ProviderId));

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MarkAsComplete(int yearId, ReportType type)
        {
            _reportRepository.SetCompleted(yearId, type, DateHelper.GetToday());
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult MarkAsNotComplete(int yearId, ReportType type)
        {
            _reportRepository.SetNotCompleted(yearId, type);
            _reportRepository.SetNotReviewed(yearId, type);
            return RedirectToAction("List");

        }
    }
}
