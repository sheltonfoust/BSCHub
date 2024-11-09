using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.MVC.ViewModels
{
    public class UserListViewModel
    {
        public UserListViewModel(List<User> users)
        {
            Users = users;
        }
        public List<User> Users { get; set; }

    }
}
