using Microsoft.AspNetCore.Mvc;

namespace SocialWorkApp.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController()
        {
            
        }

        [Route("/Error/{statusCode}")]
        public IActionResult StatusCodeHandler(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("PageNotFound");
            }
            return View("Error");
        }
    }
}
