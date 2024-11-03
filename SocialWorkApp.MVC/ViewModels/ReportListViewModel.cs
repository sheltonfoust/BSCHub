using SocialWorkApp.Domain.Reports;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.MVC.ViewModels
{
    public class ReportListViewModel
    {
        public Provider Provider { get; }
        public IEnumerable<Report> NotAcceptedReports { get; }
        public ReportListViewModel(Provider provider, IEnumerable<Report> uncompletedReports)
        {
            Provider = provider;
            NotAcceptedReports = uncompletedReports;
        }
    }
}
