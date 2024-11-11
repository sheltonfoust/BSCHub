using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Application;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Report;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialWorkApp.DataAccess
{
    public class ReportRepository : IReportRepository
    {
        private readonly SocialWorkDbContext dbContext;
        public ReportRepository(SocialWorkDbContext socialWorkDbContext)
        {
            dbContext = socialWorkDbContext;
        }

        public List<Report> ListReportsByConusltant(int userId)
        {

            var years = dbContext.ISP_Years
                          .Where(y => y.Client != null
                          && y.Client.UserId == userId && y.Client.User != null
                          && y.Client.User.IsConsultant)
                          .Include(y => y.Client)
                          .ToList();

            var reports = new List<Report>();
            foreach (var year in years)
            {
                if (year == null) continue;

                reports.Add(new Report
                {
                    ClientName = year.Client.GetName(),
                    Type = ReportType.PBSA,
                    Deadline = ReportHelper.GetDeadline(ReportType.PBSA, year, year.Client.IsSevere),
                    DueToSupervisorBy = year.Client.User.IsIndependent ? null : ReportHelper.GetDueBySupervisor(ReportType.PBSA, year, year.Client.IsSevere),
                    ISP_YearId = year.ISP_YearId,
                    IsCompleted = year.PBSA_CompletedDate != null,
                    IsReviewed = year.PBSA_ReviewedDate != null,
                });

                reports.Add(new Report
                {
                    ClientName = year.Client.GetName(),
                    Type = ReportType.PBSP,
                    Deadline = ReportHelper.GetDeadline(ReportType.PBSP, year, year.Client.IsSevere),
                    DueToSupervisorBy = year.Client.User.IsIndependent ? null : ReportHelper.GetDueBySupervisor(ReportType.PBSP, year, year.Client.IsSevere),
                    ISP_YearId = year.ISP_YearId,
                    IsCompleted = year.PBSP_CompletedDate != null,
                    IsReviewed = year.PBSP_ReviewedDate != null
                });

                reports.Add(new Report
                {
                    ClientName = year.Client.GetName(),
                    Type = ReportType.SemiAnn,
                    Deadline = ReportHelper.GetDeadline(ReportType.SemiAnn, year, year.Client.IsSevere),
                    DueToSupervisorBy = year.Client.User.IsIndependent ? null : ReportHelper.GetDueBySupervisor(ReportType.SemiAnn, year, year.Client.IsSevere),
                    ISP_YearId = year.ISP_YearId,
                    IsCompleted = year.SemiAnnCompletedDate != null,
                    IsReviewed = year.SemiAnnReviewedDate != null
                });

                if (year.HasBCIP)
                {
                    new Report
                    {
                        ClientName = year.Client.GetName(),
                        Type = ReportType.BCIP,
                        Deadline = ReportHelper.GetDeadline(ReportType.BCIP, year, year.Client.IsSevere),
                        DueToSupervisorBy = year.Client.User.IsIndependent ? null : ReportHelper.GetDueBySupervisor(ReportType.BCIP, year, year.Client.IsSevere),
                        ISP_YearId = year.ISP_YearId,
                        IsCompleted = year.BCIP_CompletedDate != null,
                        IsReviewed = year.BCIP_ReviewedDate != null
                    };
                }
                if (year.HasPPMP)
                {
                    new Report
                    {
                        ClientName = year.Client.GetName(),
                        Type = ReportType.PPMP,
                        Deadline = ReportHelper.GetDeadline(ReportType.PPMP, year, year.Client.IsSevere),
                        DueToSupervisorBy = year.Client.User.IsIndependent ? null : ReportHelper.GetDueBySupervisor(ReportType.PPMP, year, year.Client.IsSevere),
                        ISP_YearId = year.ISP_YearId,
                        IsCompleted = year.PPMP_CompletedDate != null,
                        IsReviewed = year.PPMP_ReviewedDate != null
                    };
                }
                
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
