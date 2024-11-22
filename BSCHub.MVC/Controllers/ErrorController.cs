using Microsoft.AspNetCore.Mvc;

namespace BSCHub.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController()
        {
            
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            return View("Error");
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
