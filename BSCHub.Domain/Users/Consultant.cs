using BSCHub.Domain.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCHub.Domain.Users
{
    public class Consultant
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsIndependent { get; set; }
    }
}