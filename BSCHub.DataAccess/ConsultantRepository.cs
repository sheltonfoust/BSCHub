using Microsoft.EntityFrameworkCore;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.Domain.Users;

namespace BSCHub.DataAccess
{
    public class ConsultantRepository : IConsultantRepository
    {

        private readonly SocialWorkDbContext dbContext;
        public ConsultantRepository(SocialWorkDbContext socialWorkDbContext)
        {
            this.dbContext = socialWorkDbContext;
        }


        public Consultant? GetConsultant(int id)
        {

            var user = dbContext.Users.Find(id);
            if (user == null)
                return null;
            if (!user.IsConsultant)
                return null;
            return new Consultant()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsIndependent = user.IsIndependent
            };
        }

        public List<Consultant> GetConsultants()
        {
            return dbContext.Users
                .Where(u => u.IsConsultant)
                .Select(u => new Consultant()
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsIndependent = u.IsIndependent
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();
        }

    }
}
