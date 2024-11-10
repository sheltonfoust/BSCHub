using System.ComponentModel.DataAnnotations;

namespace SocialWorkApp.Domain.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public bool IsProvider { get; set; }
        public bool IsAdmin { get; set; }
        public Provider? Provider { get; set; }

    }
}
