using SocialWorkApp.Domain.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialWorkApp.Domain.Users
{
    public class Provider
    {


        public int ProviderId { get; set; }
        [NotMapped]
        public string FirstName
        { 
            get
            {
                return User?.FirstName ?? "";
            }
            set
            {
                if (User != null)
                {
                    User.FirstName = value;
                }
            }
        }
        [NotMapped]
        public string LastName
        {
            get
            {
                return User?.LastName ?? "";
            }
            set
            {
                if (User != null)
                {
                    User.LastName = value;
                }
            }
        }


        public bool IsIndependent { get; set; }
        public User? User { get; set; }
    }
}