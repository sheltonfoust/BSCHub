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

        public User? GetUser(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public List<User> ListUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return;
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return;
        }




    }
}
