using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Reports;

namespace SocialWorkApp.DataAccess
{
    public class ReportRepository : IReportRepository
    {
        private readonly SocialWorkDbContext dbContext;
        public ReportRepository(SocialWorkDbContext socialWorkDbContext)
        {
            this.dbContext = socialWorkDbContext;
        }

        public List<ReportEntity> ListByProvider(int providerId)
        {
            throw new NotImplementedException();
        }
    }
}
