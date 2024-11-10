using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
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

                var user = GetUserWithProvider(userViewModel);

  
                _userRepository.AddUserWithProvider(user);

                ModelState.Clear();

                return RedirectToAction("List");
            }
            return View("Add", new UserViewModel());
        }

        public IActionResult Edit(int userId)
        {
            var user = _userRepository.GetUserWithProvider(userId);
            if (user == null) 
            {
                return NotFound();
            }
            return View(GetViewModel(user));
            
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel, int userId)
        {
            if (ModelState.IsValid)
            {
                userViewModel.UserId = userId;
                _userRepository.UpdateUserWithProvider(
                    GetUserWithProvider(userViewModel));
                ModelState.Clear();
                return RedirectToAction("List");
            }
            var user = _userRepository.GetUserWithProvider(userViewModel.UserId);

            if (user == null)
            {
                return NotFound();
            }
            return View(GetViewModel(user));
        }

        private UserViewModel GetViewModel(User user)
        {
            var viewModel = new UserViewModel();
            viewModel.IsProvider = user.IsProvider;
            viewModel.UserId = user.UserId;
            viewModel.IsProvider = user.IsProvider;
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            viewModel.IsIndependent = user.Provider?.IsIndependent ?? false;
            return viewModel;
        }

        private User GetUserWithProvider(UserViewModel userViewModel)
        {
            var provider = GetProvider(userViewModel);
            var user = GetUser(userViewModel);
            provider.User = user;
            user.Provider = provider;
            return user;
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
            user.UserId = userViewModel.UserId;
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.IsProvider = userViewModel.IsProvider;
            user.IsAdmin = userViewModel.IsAdmin;
            return user;
        }
        
    }
}
