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
            var users = _userRepository.ListUsers();
            return View(new UserListViewModel(users));
        }


        public IActionResult Add()
        {
            return View(new User());
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
            return View("Add", new User());
        }

        public IActionResult Edit(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null) 
            {
                return NotFound();
            }
            return View(user);
            
        }

        [HttpPost]
        public IActionResult Edit(User user, int userId)
        {
            if (ModelState.IsValid)
            {
                user.UserId = userId;
                _userRepository.UpdateUser(user);
                ModelState.Clear();
                return RedirectToAction("List");
            }
            var userInDb = _userRepository.GetUser(userId);

            if (userInDb == null)
            {
                return NotFound();
            }
            return View(userInDb);
        }

        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {


            if (ModelState.IsValid)
            {
                _userRepository.DeleteUser(userId);

                return RedirectToAction("List");

            }
            return NoContent();
        }


    }
}
