using Microsoft.AspNetCore.Mvc;

namespace SocialWorkApp.MVC.Controllers
{
    public class NoticeController : Controller
    {
        public IActionResult Copyright()
        {
            return View();
        }
    }
}
