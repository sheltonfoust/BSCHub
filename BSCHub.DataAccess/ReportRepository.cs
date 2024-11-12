using Microsoft.EntityFrameworkCore;
using BSCHub.Application;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.Domain.Reports;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BSCHub.Domain.Dates;

namespace BSCHub.DataAccess
{
    public class ReportRepository : IReportRepository
    {
        private readonly SocialWorkDbContext dbContext;
        public ReportRepository(SocialWorkDbContext socialWorkDbContext)
        {
            dbContext = socialWorkDbContext;
        }

        public List<Report> ListReportsByConsultant(int userId)
        {

            var years = dbContext.ISP_Years
                          .Where(y => y.Client != null
                          && y.Client.UserId == userId && y.Client.User != null
                          && y.Client.User.IsConsultant)
                          .Include(y => y.Client)
                          .ThenInclude(c => c.User)
                          .ToList();
            return GetReportsFromYears(years);
        }

        public List<Report> ListReportsByClient(int clientId)
        {
            var years = dbContext.ISP_Years
                .Where(y => y.Client != null
                && y.Client.ClientId == clientId)
                .Include(y => y.Client)
                .ToList();
            return GetReportsFromYears(years);

        }





        // Years need to have non null clients
        internal static List<Report> GetReportsFromYears(List<ISP_Year>? years)
        {
            var reports = new List<Report>();
            if (years == null)
                return reports;
            foreach (var year in years)
            {
                if (year == null) continue;

                reports.AddRange(ReportHelper.GetYearReports(year).Values);

            }
            return reports;
        }


        public void SetCompleted(int yearId, ReportType type, DateOnly date)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year == null) return;

            switch (type)
            {
                case ReportType.PBSA:
                    year.PBSA_CompletedDate = date;
                    break;
                case ReportType.PBSP:
                    year.PBSP_CompletedDate = date;
                    break;
                case ReportType.SemiAnn:
                    year.SemiAnnCompletedDate = date;
                    break;
                case ReportType.BCIP:
                    year.BCIP_CompletedDate = date;
                    break;
                case ReportType.PPMP:
                    year.PPMP_CompletedDate = date;
                    break;
                default:
                    break;
            }
            dbContext.SaveChanges();
        }

        public void SetReviewed(int yearId, ReportType type, DateOnly date)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year == null) return;

            switch (type)
            {
                case ReportType.PBSA:
                    year.PBSA_ReviewedDate = date;
                    break;
                case ReportType.PBSP:
                    year.PBSP_ReviewedDate = date;
                    break;
                case ReportType.SemiAnn:
                    year.SemiAnnReviewedDate = date;
                    break;
                case ReportType.BCIP:
                    year.BCIP_ReviewedDate = date;
                    break;
                case ReportType.PPMP:
                    year.PPMP_ReviewedDate = date;
                    break;
                default:
                    break;
            }
            dbContext.SaveChanges();
        }

        public void SetNotCompleted(int yearId, ReportType type)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year == null) return;

            switch (type)
            {
                case ReportType.PBSA:
                    year.PBSA_CompletedDate = null;
                    break;
                case ReportType.PBSP:
                    year.PBSP_CompletedDate = null;
                    break;
                case ReportType.SemiAnn:
                    year.SemiAnnCompletedDate = null;
                    break;
                case ReportType.BCIP:
                    year.BCIP_CompletedDate = null;
                    break;
                case ReportType.PPMP:
                    year.PPMP_CompletedDate = null;
                    break;
                default:
                    break;
            }
            dbContext.SaveChanges();
        }

        public void SetNotReviewed(int yearId, ReportType type)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year == null) return;

            switch (type)
            {
                case ReportType.PBSA:
                    year.PBSA_ReviewedDate = null;
                    break;
                case ReportType.PBSP:
                    year.PBSP_ReviewedDate = null;
                    break;
                case ReportType.SemiAnn:
                    year.SemiAnnReviewedDate = null;
                    break;
                case ReportType.BCIP:
                    year.BCIP_ReviewedDate = null;
                    break;
                case ReportType.PPMP:
                    year.PPMP_ReviewedDate = null;
                    break;
                default:
                    break;
            }
            dbContext.SaveChanges();
        }
    }
}
