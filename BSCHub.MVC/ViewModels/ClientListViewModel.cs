using Microsoft.AspNetCore.Mvc.Rendering;
using BSCHub.Domain.Clients;
using BSCHub.Domain.Users;

namespace BSCHub.MVC.ViewModels
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
