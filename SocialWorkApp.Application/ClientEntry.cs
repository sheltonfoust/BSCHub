using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application
{
    public class ClientEntry
    {
        public ClientEntry(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
