using SocialWorkApp.Domain.Reports;

namespace SocialWorkApp.MVC.ViewModels
{
    public class ReportListCardViewModel
    {
        public string Name { get; }
        public IEnumerable<Report> Reports { get;}
        public ReportListCardViewModel(string name, IEnumerable<Report> reports)
        {
            Name = name;
            Reports = reports;
        }
    }
}
