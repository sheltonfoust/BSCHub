using Microsoft.AspNetCore.Mvc;

namespace BSCHub.MVC.Controllers
{
    public class NoticeController : Controller
    {
        public IActionResult Copyright()
        {
            return View();
        }
    }
}
