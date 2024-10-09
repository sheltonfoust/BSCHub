using Microsoft.AspNetCore.SignalR;
using SocialWorkApp.Domain.Clients;

namespace SocialWorkApp.MVC.ViewModels
{
    public class ClientListViewModel
    {
        public ClientListViewModel(IEnumerable<Client> clients)
        {
            Clients = clients;
            NewClient = new Client();
        }
        public IEnumerable<Client> Clients { get; }
        public Client NewClient { get; }
    }
}
