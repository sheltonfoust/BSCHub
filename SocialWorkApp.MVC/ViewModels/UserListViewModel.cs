using BSCHub.Domain.Users;

namespace BSCHub.MVC.ViewModels
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
