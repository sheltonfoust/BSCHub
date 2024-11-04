using SocialWorkApp.Domain.Users;
using SocialWorkApp.Domain.Report;
namespace SocialWorkApp.MVC.ViewModels
{
    public class ReportListViewModel
    {
        public ReportListViewModel(Provider provider, List<Report> reports)
        {
            Provider = provider;
            Reports = reports;
        }
        public List<Report> Reports { get; set; }
        public List<Report> CompletedReports => Reports.Where(r => r.IsCompleted).ToList()
                                                       .OrderByDescending(r => r.Deadline == null)
                                                       .ThenBy(r => r.Deadline).ToList();
        public List<Report> NotCompletedReports => Reports.Where(r => !r.IsCompleted).ToList()
                                                       .OrderByDescending(r => r.Deadline == null)
                                                       .ThenBy(r => r.Deadline).ToList();

        public Provider Provider { get; set; }

    }
}
