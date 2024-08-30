using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain
{
    public class Provider : User
    {
        public override bool IsProvider => true;
        public List<Client> Clients { get; } = new List<Client>();
        public List<Report> Reports { get; set; }  = new List<Report>();
    }
}
