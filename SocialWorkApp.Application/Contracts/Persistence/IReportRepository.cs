using SocialWorkApp.Domain.Reports;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IReportRepository : IAsyncRepository<Report>
    {
        Task<IReadOnlyList<Report>> ListByProvider(int providerId);
        Task<IReadOnlyList<Report>> ListByClient(int clientId);
    }
}
