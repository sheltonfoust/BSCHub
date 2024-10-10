using Microsoft.AspNetCore.Mvc.Rendering;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.MVC.ViewModels
{
    public class ClientFormViewModel
    {
        public List<SelectListItem> Providers { get; set; }
        public Client Client { get; set; }

        public ClientFormViewModel(List<SelectListItem> providers)
        {
            Providers = providers;
            Client = new Client();
            Client.ISP_YearStartDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
