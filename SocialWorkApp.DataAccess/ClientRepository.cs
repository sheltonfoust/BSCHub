using Microsoft.EntityFrameworkCore;
using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;

namespace SocialWorkApp.DataAccess
{
    public class ClientRepository : IClientRepository
    {
        private readonly SocialWorkDbContext dbContext;
        public ClientRepository(SocialWorkDbContext socialWorkDbContext)
        {
            dbContext = socialWorkDbContext;
        }

        public void Add(Client client)
        {
            dbContext.Clients.Add(client);
        }

        public IReadOnlyCollection<Client> ListClients()
        {
            return dbContext.Clients.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
        }

        public IReadOnlyCollection<Client> ListClientsByProvider(int providerId)
        {
            return dbContext.Clients.Where(c => c.Provider.ProviderId == providerId).OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
        }
    }
}
