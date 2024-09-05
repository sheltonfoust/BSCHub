using SocialWorkApp.Domain.Reports;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.Domain.Clients
{
    public class Client
    {


        public Client(string firstName, string lastName, DateOnly ISP_YearStartDate)
        {
            FirstName = firstName;
            LastName = lastName;
            this.ISP_YearStartDate = ISP_YearStartDate;
        }

        private ClientReportInfo? reportInfo;

        public bool IsSevere 
        {
            get
            {
                return reportInfo == null ? false : reportInfo.isSevere;
            }

        }

        public DateOnly ISP_MeetingDate
        {
            get
            {
                return reportInfo.ISP_MeetingDate;
            }
        }

        
        public bool Has(ReportType report)
        {
            return reportInfo == null ? false : reportInfo.Has(report);
        }



        private Report[]? reports;
        private Report[] Reports
        {
            get
            {
                if (reports == null)
                {
                    reports = new Report[Enum.GetValues(typeof(ReportType)).Length];
                    reports[(int)PBSA] = new Report(PBSA, ISP_MeetingDate.AddDays(-14));
                    reports[(int)PBSP] = new Report(PBSP, IsSevere ? ISP_MeetingDate.AddDays(14) : ISP_YearStartDate);
                    reports[(int)BCIP] = new Report(BCIP, ISP_YearStartDate);
                    reports[(int)PPMP] = new Report(PPMP, ISP_YearStartDate);
                    reports[(int)RMP] = new Report(RMP, ISP_YearStartDate);

                }
                return reports;
            }
            

        }
        


        public Report GetReport(ReportType reportType)
        {
            if (!Has(reportType))
                throw new ArgumentException("Client Does Not Have " + nameof(reportType) + ".");
            return Reports[(int)reportType];
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly ISP_YearStartDate { get; set; }
        public void InputReportInfo(ClientReportInfo reportInfo)
        {
            this.reportInfo = reportInfo;
        }

        public List<Report> GetReports()
        {
            var reports = new List<Report>();
            foreach (var  report in Reports)
            {
                if (Has(report.Type))
                    reports.Add(report);
            }
            return reports;
        }

        
    }
    

  
}