using SocialWorkApp.Domain.Reports;
using SocialWorkApp.Domain.Users;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.Domain.Clients
{
    public class Client
    {
        public int ClientId { get; set; }
        public Provider? Provider { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly ISP_YearStartDate { get; set; }
    }
}