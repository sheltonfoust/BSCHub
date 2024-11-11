using SocialWorkApp.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IClientRepository
    {
        Client? GetClient(int clientId);
        IReadOnlyCollection<Client> ListClientsWithConsultants();
        IReadOnlyCollection<Client> ListClientsByConsultant(int consultantId);
        void Add(Client client);
        void Update(Client client);
        void Delete(int clientId);
    }
}
