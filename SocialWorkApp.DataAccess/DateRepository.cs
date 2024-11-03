using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Reports;

namespace SocialWorkApp.DataAccess
{
    public class DateRepository : IDateRepository
    {
        private readonly SocialWorkDbContext dbContext;
        public DateRepository(SocialWorkDbContext socialWorkDbContext)
        {
            dbContext = socialWorkDbContext;
        }

        public List<ISP_Year>? GetISPYears(int clientId)
        {

            if (!dbContext.Clients.Any(c => c.ClientId == clientId))
                return null;
            return dbContext.ISP_Years.Where(y => y.ClientId == clientId).ToList();
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
            dbContext.ISP_Years.Add(ISP_Year);
            
            var reportTypes = new List<ReportType>( { ReportType.PBSA, ReportType.PBSP, S});

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
                year.StartDate = newYearStart;
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
    }
}
