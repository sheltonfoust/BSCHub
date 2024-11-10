using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Users;
using System.Runtime.CompilerServices;

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
            if (!user.IsProvider)
            {
                user.Provider = null;
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

        public User? GetUserWithProvider(int userId)
        {
            return _dbContext.Users.Where(u => u.UserId == userId).Include(u => u.Provider).FirstOrDefault();
        }

        public List<User> ListUsers()
        {
            return _dbContext.Users.ToList();
        }

        public List<User> ListUsersWithProviders()
        {
            return _dbContext.Users.Include(u => u.Provider).ToList();
        }

        public void UpdateUserWithProvider(User user)
        {
            if (user.IsProvider && user.Provider != null)
            {
                _dbContext.Providers.RemoveRange(
                    _dbContext.Providers.Where(p => p.ProviderId != user.Provider.ProviderId
                                               && p.UserId == user.UserId));
                if (_dbContext.Providers.Any(p => p.ProviderId == user.Provider.ProviderId))
                {
                    _dbContext.Providers.Update(Copy(user.Provider));
                }
                else
                {
                    _dbContext.Providers.Add(Copy(user.Provider));
                }
                _dbContext.SaveChanges();

            }
            if (!user.IsProvider)
            {
                _dbContext.Providers.RemoveRange(
                    _dbContext.Providers.Where(p => p.UserId == user.UserId));
                _dbContext.SaveChanges();

            }

            var userCopy = new User()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = user.IsAdmin,
                IsProvider = user.IsProvider
            };

            _dbContext.Users.Update(userCopy);
            _dbContext.SaveChanges();
            return;
            
        }

        private Provider Copy(Provider provider)
        {
            return new Provider()
            {
                ProviderId = provider.ProviderId,
                UserId = provider.UserId,
                FirstName = provider.FirstName,
                LastName = provider.LastName,
                IsIndependent = provider.IsIndependent,
            };
        }
    }
}
