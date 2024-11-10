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
            var users = _userRepository.ListUsersWithProviders();
            return View(new UserListViewModel(users));
        }


        public IActionResult Add()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult Add(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {

                var user = GetUser(userViewModel);
                var provider = GetProvider(userViewModel);

                if (userViewModel.IsProvider)
                {
                    provider.User = user;
                    user.Provider = provider;
                    _providerRepository.Add(provider);
                }                
                _userRepository.AddUser(user);

                ModelState.Clear();

                return RedirectToAction("List");
            }
            return View("Add", new UserViewModel());
        }



        private Provider GetProvider(UserViewModel userViewModel)
        {
            var provider = new Provider();
            provider.FirstName = userViewModel.FirstName;
            provider.LastName = userViewModel.LastName;
            provider.IsIndependent = userViewModel.IsIndependent;
            return provider;
        }
        private User GetUser(UserViewModel userViewModel)
        {
            var user = new User();
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.IsProvider = userViewModel.IsProvider;
            user.IsAdmin = userViewModel.IsAdmin;
            return user;
        }
        
    }
}
