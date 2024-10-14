using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.MVC.ViewModels;

namespace SocialWorkApp.MVC.Components
{
    public class EditClientForm :  ViewComponent
    {

        public IViewComponentResult Invoke(List<SelectListItem> providers, Client client)
        {
            var viewModel = new ClientFormViewModel(providers, client);
            return View(viewModel);
        }
    }
}
