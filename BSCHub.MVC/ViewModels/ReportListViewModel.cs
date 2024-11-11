using BSCHub.Domain.Users;
using BSCHub.Domain.Report;
namespace BSCHub.MVC.ViewModels
{
    public class ReportListViewModel
    {
        public ReportListViewModel(Consultant consultant, List<Report> reports)
        {
            Consultant = consultant;
            Reports = reports;
        }
        public List<Report> Reports { get; set; }
        public List<Report> CompletedReports => Reports.Where(r => r.IsCompleted).ToList()
                                                       .OrderByDescending(r => r.Deadline == null)
                                                       .ThenBy(r => r.Deadline).ToList();
        public List<Report> NotCompletedReports => Reports.Where(r => !r.IsCompleted).ToList()
                                                       .OrderByDescending(r => r.Deadline == null)
                                                       .ThenBy(r => r.Deadline).ToList();

        public Consultant Consultant { get; set; }

    }
}
