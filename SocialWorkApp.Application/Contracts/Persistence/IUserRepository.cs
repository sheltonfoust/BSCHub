using SocialWorkApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public void DeleteUser(int userId);
        public User? GetUser(int userId);
        public List<User> ListUsers();
        public void UpdateUser(User user);

    }
}
