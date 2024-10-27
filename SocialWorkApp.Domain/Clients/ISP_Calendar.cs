using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain.Clients
{
    public class ISP_Calendar
    {
        [Key]
        public int CalendarId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public Client? Client { get; set; }
        public List<ISP_YearStartDate> ISP_YearStartDates = new List<ISP_YearStartDate>();
        public List<ISP_MeetingDate> ISP_MeetingDates = new List<ISP_MeetingDate>();
    }
}
