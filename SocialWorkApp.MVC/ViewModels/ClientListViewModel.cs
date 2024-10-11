using Microsoft.AspNetCore.Mvc.Rendering;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.MVC.ViewModels
{
    public class ClientListViewModel
    {
        public ClientListViewModel(List<Client> clients, List<SelectListItem> providers, bool showModal = false)
        {
            Clients = clients;
            Providers = providers;
            ShowModal = showModal;
        }
        public List<SelectListItem> Providers { get; }
        public List<Client> Clients { get; }
        public bool ShowModal { get; }
    }
}
