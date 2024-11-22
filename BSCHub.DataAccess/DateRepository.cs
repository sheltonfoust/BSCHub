using BSCHub.Application;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.Domain.Dates;
using BSCHub.Domain.Reports;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BSCHub.DataAccess
{
    public class DateRepository : IDateRepository
    {
        private readonly SocialWorkDbContext dbContext;
        public DateRepository(SocialWorkDbContext socialWorkDbContext)
        {
            dbContext = socialWorkDbContext;
        }

        public List<YearWithReports>? GetISPYearsWithReports(int clientId)
        {

            if (!dbContext.Clients.Any(c => c.ClientId == clientId))
                return null;
            var years = dbContext.ISP_Years
                .Where(y => y.Client != null 
                && y.Client.ClientId == clientId)
                .Include(y => y.Client)
                .ThenInclude(c => c.User)
                .OrderByDescending(y => y.StartDate)
                .ToList();
            var result = new List<YearWithReports>();
            foreach (var year in years)
            {

                var reports = ReportHelper.GetYearReports(year);
                var yearWithReports = new YearWithReports()
                {
                    ISP_Year = year,
                    PBSA = reports[ReportType.PBSA],
                    PBSP = reports[ReportType.PBSP],
                    SemiAnn = reports[ReportType.SemiAnn],
                };
                if (reports.TryGetValue(ReportType.BCIP, out var BCIP))
                {
                    yearWithReports.BCIP = BCIP;
                }
                if (reports.TryGetValue(ReportType.PPMP, out var PPMP))
                {
                    yearWithReports.PPMP = PPMP;
                }

                yearWithReports.NewStartDate = year.StartDate;
                yearWithReports.NewMeetingDate = year.MeetingDate ?? year.StartDate.AddDaysSafe(-90);

                result.Add(yearWithReports);
            }


            return result;
        }

        public void AddYear(int clientId, DateOnly startDate)
        {
            var client = dbContext.Clients.Find(clientId);
            if (client == null)
                return;
            var ISP_Year = new ISP_Year();
            ISP_Year.ClientId = clientId;
            ISP_Year.Client = client;
            ISP_Year.StartDate = startDate;
            ISP_Year.HasBCIP = client.NeedsBCIP;
            ISP_Year.HasPPMP = client.NeedsPPMP;
            ISP_Year.IsSevere = client.IsSevere;

            dbContext.ISP_Years.Add(ISP_Year);

            dbContext.SaveChanges();
        }


        public void DeleteYear(int yearId)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year != null)
            {
                dbContext.ISP_Years.Remove(year);
                dbContext.SaveChanges();
            }
        }

        public void UpdateYear(DateOnly newYearStart, int ISP_YearId)
        {
            var year = dbContext.ISP_Years.Find(ISP_YearId);
            if (year != null)
            {
                var client = dbContext.Clients.Find(year.ClientId);
                year.StartDate = newYearStart;
                if (client != null)
                {
                    year.HasBCIP = client.NeedsBCIP;
                    year.HasPPMP = client.NeedsPPMP;
                }
                dbContext.ISP_Years.Update(year);
                dbContext.SaveChanges();
            }
            
        }

        public void UpdateMeetingDate(DateOnly meetingDate, int ISP_YearId)
        {
            var year = dbContext.ISP_Years.Find(ISP_YearId);
            if (year != null)
            {
                year.MeetingDate = meetingDate;
                dbContext.ISP_Years.Update(year);
                dbContext.SaveChanges();
            }
        }


        public ISP_Year? GetYear(int yearId)
        {
            return dbContext.ISP_Years.Find(yearId);
        }

        public void SetHasBCIP(int yearId, bool value)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year != null)
            {
                year.HasBCIP = value;
                dbContext.SaveChanges();
            }
        }
        public void SetHasPPMP(int yearId, bool value)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year != null)
            {
                year.HasPPMP = value;
                dbContext.SaveChanges();
            }
        }

        public void SetIsSevere(int yearId, bool value)
        {
            var year = dbContext.ISP_Years.Find(yearId);
            if (year != null)
            {
                year.IsSevere = value;
                dbContext.SaveChanges();
            }
        }



    }
}
