using Microsoft.AspNetCore.Mvc;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Controllers
{
    public class UserController : Controller
    {
        IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult List()
        {
            var users = _userRepository.ListUsers();
            return View(new UserListViewModel(users));
        }
    }
}
