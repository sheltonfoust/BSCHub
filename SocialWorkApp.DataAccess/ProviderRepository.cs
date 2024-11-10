using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.DataAccess
{
    public class ProviderRepository : IProviderRepository
    {

        private readonly SocialWorkDbContext dbContext;
        public ProviderRepository(SocialWorkDbContext socialWorkDbContext)
        {
            this.dbContext = socialWorkDbContext;
        }


        public Provider? GetProvider(int id)
        {

            var user = dbContext.Users.Find(id);
            if (user == null)
                return null;
            if (!user.IsProvider)
                return null;
            return new Provider()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsIndependent = user.IsIndependent
            };
        }

        public List<Provider> ListProviders()
        {
            return dbContext.Users
                .Where(u => u.IsProvider)
                .Select(u => new Provider()
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsIndependent = u.IsIndependent
                })
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();
        }

    }
}
