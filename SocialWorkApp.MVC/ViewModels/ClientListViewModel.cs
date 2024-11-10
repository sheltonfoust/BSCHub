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
            IsAllProviders = true;
            Provider = null;
        }
        public ClientListViewModel(List<Client> clients, Provider provider)
        {
            Clients = clients;
            IsAllProviders = false;
            Provider = provider;
        }
        public List<Client> Clients { get; }
        public bool IsAllProviders { get; set; }
        public Provider? Provider { get; set; }
    }
}
