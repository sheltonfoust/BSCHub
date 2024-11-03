﻿using SocialWorkApp.Application.Contracts.Persistence;
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
        public List<Report> ListByProvider(int providerId)
        {
            return dbContext.Reports.Where(r => r.Client != null && r.Client.Provider != null && r.Client.Provider.ProviderId == providerId)
                .ToList();
        }
    }
}
