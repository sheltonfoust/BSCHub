
using SocialWorkApp.Domain.Reports;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.Domain.Clients
{
    public class ClientReportInfo
    {


        public ClientReportInfo()
        {

        }

        public ClientReportInfo(DateOnly dateOnly, bool isSevere, bool hasBCIP, bool hasPPMP, bool hasRMP)
        {
            this.ISP_MeetingDate = dateOnly;
            this.isSevere = isSevere;
            this.hasBCIP = hasBCIP;
            this.hasPPMP = hasPPMP;
            this.hasRMP = hasRMP;
        }

        public DateOnly ISP_MeetingDate { get; set; }
        public bool isSevere { get; set; }
        public bool hasBCIP { get; set; }
        public bool hasPPMP { get; set; }
        public bool hasRMP { get; set; }
        internal bool Has(ReportType report)
        {
            switch (report)
            {
                case PBSA:
                    return true;
                case PBSP:
                    return true;
                case BCIP:
                    return this.hasBCIP;
                case PPMP:
                    return this.hasPPMP;
                case RMP:
                    return this.hasRMP;
                default: return false;
            }
        }
    }
}