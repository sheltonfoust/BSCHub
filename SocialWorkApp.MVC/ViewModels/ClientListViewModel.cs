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
            isAllConsultants = true;
            Consultant = null;
        }
        public ClientListViewModel(List<Client> clients, Consultant consultant)
        {
            Clients = clients;
            isAllConsultants = false;
            Consultant = consultant;
        }
        public List<Client> Clients { get; }
        public bool isAllConsultants { get; set; }
        public Consultant? Consultant { get; set; }
    }
}
