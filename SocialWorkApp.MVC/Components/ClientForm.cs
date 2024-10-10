using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialWorkApp.DataAccess;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Reports;
using SocialWorkApp.Domain.Users;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Components
{
    public class ClientForm : ViewComponent
    {
        public IViewComponentResult Invoke(List<SelectListItem> providers)
        {
            var viewModel = new ClientFormViewModel(providers);
            return View(viewModel);
        }
    }
}
