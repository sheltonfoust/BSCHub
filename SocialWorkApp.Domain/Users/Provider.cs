using SocialWorkApp.Domain.Clients;

namespace SocialWorkApp.Domain.Users
{
    public class Provider
    {
        public Provider()
        {
        }

        public int ProviderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Client> Clients { get; internal set; } = new List<Client>();

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void ReassignClient(Client client, Provider newProvider)
        {
            Clients.Remove(client);
            newProvider.Clients.Add(client);
        }
    }
}