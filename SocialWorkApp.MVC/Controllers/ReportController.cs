using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;

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
            ViewBag.CurrentProvider = "Mickey Mouse";
            return View(reportRepository.ListAllAsync());
        }
    }
}
