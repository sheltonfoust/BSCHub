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

        public IActionResult List(int providerId)
        {
            var provider = _providerRepository.GetProvider(providerId);
            if (provider == null)
                return NotFound();
            var viewModel = new ReportListViewModel(provider, _reportRepository
                .ListReportsByProvider(provider.UserId));

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
