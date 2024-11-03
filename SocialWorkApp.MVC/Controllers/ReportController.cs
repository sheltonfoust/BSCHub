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

    }
}
