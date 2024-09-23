using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Users;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportRepository reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public IActionResult List()
        {
            var reports = reportRepository.ListByProvider(1);
            var viewModel = new ReportListViewModel(
                new Provider() { FirstName = "Mickey", LastName = "Mouse"}, 
                reports);
            return View(viewModel);
        }
    }
}
