using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Domain.Reports;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Components
{
    public class ReportListCard : ViewComponent
    {
        public IViewComponentResult Invoke(string name, IEnumerable<Report> reports)
        {
            var viewModel = new ReportListCardViewModel(name, reports);
            return View(viewModel);
        }
    }
}
