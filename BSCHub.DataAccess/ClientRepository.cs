﻿using Microsoft.EntityFrameworkCore;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.Domain.Clients;

namespace BSCHub.DataAccess
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

        

        public IReadOnlyCollection<Client> ListClientsWithConsultants()
        {
            return dbContext.Clients
                .Include(c => c.User)
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .ToList();
        }

        public IReadOnlyCollection<Client> ListClientsByConsultant(int userId)
        {
            return dbContext.Clients
                .Where(c => c.User != null && c.User.UserId == userId
                && c.User.IsConsultant)
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
