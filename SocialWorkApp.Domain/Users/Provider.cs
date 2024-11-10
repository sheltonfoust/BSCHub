using SocialWorkApp.Domain.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialWorkApp.Domain.Users
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsIndependent { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        List<Client> Clients { get; set; }
    }
}