using Microsoft.AspNetCore.Mvc.Rendering;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.MVC.ViewModels
{
    public class ClientListViewModel
    {
        public ClientListViewModel(List<Client> clients)
        {
            Clients = clients;
        }
        public List<Client> Clients { get; }
    }
}
