using SocialWorkApp.Domain.Reports;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IReportRepository : IAsyncRepository<Report>
    {
        Task<IReadOnlyList<Report>> ListByProvier(int provierId);
        Task<IReadOnlyList<Report>> ListByClient(int clientId);
    }
}
