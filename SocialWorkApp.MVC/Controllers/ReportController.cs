using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Users;
using SocialWorkApp.MVC.ViewModels;
using SocialWorkApp.Domain.Reports;
using SocialWorkApp.Domain.Clients;

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
            reports = new List<Report> {new Report()
            {
                Client = new Client() { FirstName = "Sandy", LastName = "Cheeks" },
                ClientId = 1,
                DueDate = new DateOnly(2024, 11, 3),
                ReviewedDate = null,
                ReportId = 1,
                Status = Status.Pending,
                Type = ReportType.PBSA
            } };
            var viewModel = new ReportListViewModel(
                new Provider() { FirstName = "Mickey", LastName = "Mouse"}, 
                reports);
            return View(viewModel);
        }
    }
}
