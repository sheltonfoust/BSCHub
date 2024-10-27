using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Domain.Clients;

namespace SocialWorkApp.DataAccess
{
    public class DateRepository
    {
        private readonly SocialWorkDbContext dbContext;
        public DateRepository(SocialWorkDbContext socialWorkDbContext)
        {
            dbContext = socialWorkDbContext;
        }

        public ISP_Calendar? GetCalendarByClient(int clientId)
        {
            if (!dbContext.Clients.Any(c => c.ClientId == clientId))
                return null;
            EnsureCalendarExists(clientId);

            return dbContext.Calendars.Where(c => c.ClientId == clientId).FirstOrDefault();
        }

        private void EnsureCalendarExists(int clientId)
        {
            var exists = dbContext.Calendars.Any(c=> c.ClientId == clientId);
            if (!exists)
            {
                dbContext.Calendars.Add(new ISP_Calendar { ClientId = clientId });
                dbContext.SaveChanges();
            }
        }


        



    }
}
