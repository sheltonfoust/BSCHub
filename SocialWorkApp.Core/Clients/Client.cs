using SocialWorkApp.Core.Reports;


namespace SocialWorkApp.Core.Clients
{
    public class Client
    {


        public Client(string firstName, string lastName, DateOnly ISP_YearEndDate)
        {
            FirstName = firstName;
            LastName = lastName;
            this.ISP_YearEndDate = ISP_YearEndDate;


        }

        public bool IsSevere { get; internal set; }
        public DateOnly ISP_MeetingDate { get; internal set; }
        public bool HasBCIP { get; internal set; }
        public bool HasPPMP { get; internal set; }
        public bool HasRMP { get; internal set; }

        public Report? GetReport(ReportType reportType)
        {
            throw new NotImplementedException();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly ISP_YearEndDate { get; set; }
        public void InputReportInfo(ClientReportInfo reportInfo)
        {
            IsSevere = reportInfo.isSevere;
            ISP_MeetingDate = reportInfo.ISP_MeetingDate;
            HasBCIP = reportInfo.hasBCIP;
            HasPPMP = reportInfo.hasPPMP;
            HasRMP = reportInfo.hasRMP;
        }

    }
    

  
}