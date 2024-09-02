

using SocialWorkApp.Core.Clients;

namespace SocialWorkApp.Core.Users
{
    public class Provider
    {
        public Provider()
        {
        }

        public List<Client> Clients { get; set; } = new List<Client>();

        public void AddClient(string FirstName, string LastName, DateOnly ISP_YearEndDate)
        {
            Clients.Add(new Client 
            { 
                FirstName = FirstName, 
                LastName = LastName, 
                ISP_YearEndDate = ISP_YearEndDate 
            });
        }
    }
}