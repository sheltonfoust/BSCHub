using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain.Clients
{
    public class ISP_YearStartDate
    {
        public int Id { get; set; }
        public bool Defined { get; set; }
        public DateOnly? Date { get; set; }
        public int ISP_CalendarId { get; set; }
        [Required]
        public ISP_Calendar? ISP_Calendar { get; set; }
    }
}
