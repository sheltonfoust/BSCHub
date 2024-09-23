using SocialWorkApp.Application.Contracts.Persistence;
using SocialWorkApp.Domain.Clients;
using SocialWorkApp.Domain.Reports;
using SocialWorkApp.Domain.Users;

namespace SocialWorkApp.DataAccess
{
    public class MockReportRepository : IReportRepository
    {

        private List<Client> Clients
        {
            get
            {
                var output = new List<Client>()
                {
                    new Client( "SpongeBob","Squarepants", new DateOnly(2024, 11, 1)) {ClientId = 1},
                    new Client("Patrick", "Star", new DateOnly(2024, 11, 3)) { ClientId = 2},
                    new Client("Squidward", "Tentacles", new DateOnly(2024, 12, 1)) {ClientId = 3},
                    new Client("Eugene", "Krabs", new DateOnly(2024, 5, 14)) {ClientId = 4},
                    new Client("Sheldon", "Plankton", new DateOnly(2024, 10, 20)) {ClientId = 5},
                };
                output[0].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 8, 2), false, true, false));
                output[1].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 12, 18), true, true, true));
                output[2].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 9, 1), false, false, false));
                output[3].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 7, 25), false, false, false));
                output[4].InputReportInfo(new ClientReportInfo(new DateOnly(2024, 3, 20), false, false, true));

                return output;
            }
        }

        public Task<IReadOnlyList<Report>> ListAllAsync()
        {
            var task = new Task<IReadOnlyList<Report>>(() =>
            {
                List<Report> result = new();
                
                foreach (var client in Clients)
                {
                    result.AddRange(client.GetReports());
                }
                return result.AsReadOnly();
            });
            return task;
        }



        private IReadOnlyList<Report> GetReportsByClient(int clientId)
        {
            var client = Clients.FirstOrDefault(clients => clients.ClientId == clientId);
            if (client == null)
                return new List<Report>().AsReadOnly<Report>();
            return client.GetReports().AsReadOnly();
        }
        public Task<IReadOnlyList<Report>> ListByClient(int clientId)
        {
            var task = new Task<IReadOnlyList<Report>>(() => GetReportsByClient(clientId));
            return task;  
        }

        public IReadOnlyList<Report> ListByProvider(int providerId)
        {
            /*
            var task = new Task<IReadOnlyList<Report>>(() =>
            {*/
                List<Client> clients;
                if (providerId == 1)
                {
                    clients = Clients.Take(2).ToList();
                }
                else if (providerId == 2)
                {
                    clients = Clients.Skip(2).ToList();
                }
                else
                {
                    clients = new List<Client>();
                }
                List<Report> result = new List<Report>();
                foreach (var client in clients)
                {
                    result.AddRange(client.GetReports());
                }
                return result.AsReadOnly();
           /* });
            return task;*/
        }




        public Task<Report> AddAsync(Report entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Report entity)
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task UpdateAsync(Report entity)
        {
            throw new NotImplementedException();
        }
    }
}
