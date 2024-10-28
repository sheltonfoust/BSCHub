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
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? MeetingDate { get; set; } = null;


    }
}
