using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Domain.Clients
{
    public class ISP_Year
    {
        [Key]
        public int ISP_YearId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public Client? Client { get; set; }
        public ISP_YearStartDate StartDate = new ISP_YearStartDate();
        public ISP_MeetingDate MeetingDate = new ISP_MeetingDate();

    }
}
