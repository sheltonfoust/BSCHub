using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Reports;

namespace SocialWorkApp.DataAccess
{
    public class ReportRepository : IReportRepository
    {
        public IReadOnlyCollection<Report> ListByProvider(int providerId)
        {
            return new List<Report>();
        }
    }
}
