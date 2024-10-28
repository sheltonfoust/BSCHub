using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;

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
            ISP_Year.StartDate.Date = startDate;
            ISP_Year.StartDate.Defined = true;
            dbContext.ISP_Years.Add(ISP_Year);
            dbContext.SaveChanges();
        }






    }
}
