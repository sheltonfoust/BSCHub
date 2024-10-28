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
        public Client? GetClient(int clientId)
        {
            return dbContext.Clients.Find(clientId);
        }


        public void Add(Client client)
        {
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
        }

        

        public IReadOnlyCollection<Client> ListClients()
        {
            return dbContext.Clients.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
        }

        public IReadOnlyCollection<Client> ListClientsByProvider(int providerId)
        {
            return dbContext.Clients.Where(c => c.Provider != null && c.Provider.ProviderId == providerId)
                .OrderBy(c => c.LastName).ThenBy(c => c.FirstName)
                .ToList();
        }

        public void Update(Client client)
        {
            dbContext.Clients.Update(client);
            dbContext.SaveChanges();
        }

        public void Delete(int clientId)
        {
            var client = dbContext.Clients.Find(clientId);
            if (client != null)
            {
                dbContext.Clients.Remove(client);
                dbContext.SaveChanges();
            }

        }

    }
}
