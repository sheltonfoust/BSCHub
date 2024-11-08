using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IReportRepository
    {
        List<Report> ListReportsByProvider(int providerId);
        public void SetCompleted(int yearId, ReportType type, DateOnly date);
        public void SetReviewed(int yearId, ReportType type, DateOnly date);
        public void SetNotCompleted(int yearId, ReportType type);
        public void SetNotReviewed(int yearId, ReportType type);
    }
}
