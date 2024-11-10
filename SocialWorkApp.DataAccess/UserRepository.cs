using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.DataAccess
{
    public class UserRepository : IUserRepository
    {
        SocialWorkDbContext _dbContext;
        public UserRepository(SocialWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddUserWithProvider(User user)
        {
            if (user.IsProvider && user.Provider != null)
            {
                _dbContext.Providers.Add(user.Provider);
            }
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            if (user == null)
            {
                return;
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<User> ListUsers()
        {
            return _dbContext.Users.ToList();
        }

        public List<User> ListUsersWithProviders()
        {
            return _dbContext.Users.Include(u => u.Provider).ToList();
        }
    }
}
