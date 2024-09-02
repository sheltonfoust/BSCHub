
namespace SocialWorkApp.Core.Tests.Reports
{
    internal class Client
    {
        public Client()
        {
        }

        public bool HasRMP { get; internal set; }
        public bool IsSevere { get; internal set; }
        public bool ISP_MeetingDate { get; internal set; }
        public bool HasBCIP { get; internal set; }
        public bool HasPPMP { get; internal set; }

        internal void InputReportInfo(ClientReportInfo reportInfo)
        {
            throw new NotImplementedException();
        }

    }
}