using SocialWorkApp.Core.Reports;
using static SocialWorkApp.Core.Reports.ReportType;

namespace SocialWorkApp.Core.Clients
{
    public class Client
    {


        public Client(string firstName, string lastName, DateOnly ISP_YearStartDate)
        {
            FirstName = firstName;
            LastName = lastName;
            this.ISP_YearStartDate = ISP_YearStartDate;
        }

        public bool IsSevere { get; internal set; }
        public DateOnly ISP_MeetingDate { get; internal set; }
        public bool HasBCIP { get; internal set; }
        public bool HasPPMP { get; internal set; }
        public bool HasRMP { get; internal set; }


        private Report[]? reports;
        private Report[] Reports
        {
            get
            {
                if (reports == null)
                {
                    reports = new Report[Enum.GetValues(typeof(ReportType)).Length];
                    reports[(int)PBSA] = new Report()
                    {
                        DueDate = ISP_MeetingDate.AddDays(-14)
                    };
                    reports[(int)PBSP] = new Report()
                    {
                        DueDate = IsSevere ? ISP_MeetingDate.AddDays(14) : ISP_YearStartDate,
                    };

                    reports[(int)BCIP] = new Report()
                    {
                        DueDate = ISP_YearStartDate
                    }; 
                    reports[(int)PPMP] = new Report()
                    {
                        DueDate = ISP_YearStartDate
                    };
                    reports[(int)RMP] = new Report()
                    {
                        DueDate = ISP_YearStartDate
                    };

                }
                return reports;
            }
            

        }
        


        public Report GetReport(ReportType reportType)
        {
            switch(reportType)
            {
                case BCIP:
                    if (!HasBCIP)
                    {
                        throw new ArgumentException("Client Does Not Have BCIP.");
                    }
                    break;
                case PPMP:
                    if (!HasPPMP)
                    {
                        throw new ArgumentException("Client Does Not Have PPMP.");
                    }
                    break;
                case RMP:
                    if (!HasRMP)
                    {
                        throw new ArgumentException("Client Does Not Have RMP.");
                    }
                    break;
            }
            return Reports[(int)reportType];
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly ISP_YearStartDate { get; set; }
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