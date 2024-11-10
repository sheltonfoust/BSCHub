using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialWorkApp.Application;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.DataAccess;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Users;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Controllers
{
    public class UserController : Controller
    {
        IUserRepository _userRepository;
        IProviderRepository _providerRepository;
        public UserController(IUserRepository userRepository, IProviderRepository providerRepository)
        {
            _userRepository = userRepository;
            _providerRepository = providerRepository;
        }

        public ActionResult List()
        {
            var users = _userRepository.ListUsers();
            return View(new UserListViewModel(users));
        }


        public IActionResult Add()
        {
            return View(GetAddData());
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.AddUser(user);
                ModelState.Clear();

                return RedirectToAction("List");
            }
            return View("Add", GetAddData());
        }

        private User GetAddData()
        {
            var user = new User();
            user.Provider = new Provider();
            return user;
        }

        private Provider GetProvider(User user)
        {
            return new Provider();
        }
        
    }
}
