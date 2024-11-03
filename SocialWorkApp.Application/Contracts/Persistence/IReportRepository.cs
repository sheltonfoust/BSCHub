using SocialWorkApp.Domain.Reports;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IReportRepository
    {
        public List<Report> ListByProvider(int providerId);
    }
}
