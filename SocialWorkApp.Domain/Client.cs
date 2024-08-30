using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Report> Reports { get; set; }
        public DateOnly YearBegin { get; set; }
        public DateOnly YearEnd { get; set; }
    }

}
