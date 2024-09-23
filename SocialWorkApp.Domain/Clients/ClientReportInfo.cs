
using SocialWorkApp.Domain.Reports;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.Domain.Clients
{
    public class ClientReportInfo
    {


        public ClientReportInfo()
        {

        }

        public ClientReportInfo(DateOnly dateOnly, bool isSevere, bool hasBCIP, bool hasPPMP)
        {
            this.ISP_MeetingDate = dateOnly;
            this.isSevere = isSevere;
            this.hasBCIP = hasBCIP;
            this.hasPPMP = hasPPMP;
        }

        public DateOnly ISP_MeetingDate { get; set; }
        public bool isSevere { get; set; }
        public bool hasBCIP { get; set; }
        public bool hasPPMP { get; set; }
        internal bool Has(ReportType report)
        {
            switch (report)
            {
                case PBSA:
                    return true;
                case PBSP:
                    return true;
                case SemiAnn:
                    return true;
                case BCIP:
                    return this.hasBCIP;
                case PPMP:
                    return this.hasPPMP;
                default: return false;
            }
        }
    }
}