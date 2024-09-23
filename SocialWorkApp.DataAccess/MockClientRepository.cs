using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.DataAccess
{
    public class MockClientRepository : IClientRepository
    {


            
        private List<Client> clients
        {
            get
            {
                var output = new List<Client>()
                {
                    new Client( "SpongeBob","Squarepants", new DateOnly(2024, 11, 1)) {ClientId = 1},
                    new Client("Patrick", "Star", new DateOnly(2024, 18, 3)) { ClientId = 2},
                    new Client("Squidward", "Tentacles", new DateOnly(2024, 12, 1)) {ClientId = 3},
                    new Client("Eugene", "Krabs", new DateOnly(2024, 5, 14)) {ClientId = 4},
                    new Client("Sheldon", "Plankton", new DateOnly(2024, 10, 20)) {ClientId = 5},
                };
                output[0].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 8, 2), false, true, false));
                output[1].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 12, 18), true, true, true));
                output[2].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 9, 1), false, false, false));
                output[3].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 7, 25), false, false, false));
                output[4].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 3, 20), false, false, true));

                return clients;
            }
        }




        public Task<IReadOnlyList<Client>> ListAllAsync()
        {
            return new Task<IReadOnlyList<Client>>(() => clients.AsReadOnly<Client>());
        }

        public Task<IReadOnlyList<Client>> ListByProvider(int providerId)
        {
            if (providerId == 1)
            {
                return new Task<IReadOnlyList<Client>>(() => clients.Take(2).ToList().AsReadOnly<Client>());
            }
            else if (providerId == 2)
            {
                return new Task<IReadOnlyList<Client>>(() => clients.Skip(2).ToList().AsReadOnly<Client>());
            }
            else
            {
                return new Task<IReadOnlyList<Client>>(() => new List<Client>().AsReadOnly<Client>());
            }
        }


        public Task<Client> AddAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
