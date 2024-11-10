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
        User? GetUserWithProvider(int userId);
        List<User> ListUsers();
        List<User> ListUsersWithProviders();
        void AddUserWithProvider(User user);
        void UpdateUserWithProvider(User user);
        void DeleteUser(int userId);
    }
}
