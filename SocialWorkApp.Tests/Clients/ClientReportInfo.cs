
namespace SocialWorkApp.Core.Tests.Reports
{
    internal class ClientReportInfo
    {
        public ClientReportInfo()
        {
        }

        public DateOnly ISP_MeetingDate { get; set; }
        public bool isSevere { get; set; }
        public bool hasBCIP { get; set; }
        public bool hasPPMP { get; set; }
        public bool hasRMP { get; set; }
    }
}