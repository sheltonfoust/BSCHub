using Microsoft.AspNetCore.Mvc;

namespace SocialWorkApp.MVC.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
            
        }

        public ActionResult List()
        {
            return View();
        }
    }
}
