using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public virtual bool IsProvider => false;
    }
}
