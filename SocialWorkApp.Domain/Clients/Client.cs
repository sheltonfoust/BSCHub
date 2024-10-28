using Microsoft.AspNetCore.Mvc.ModelBinding;
using SocialWorkApp.Domain.Reports;
using SocialWorkApp.Domain.Users;
using System.ComponentModel.DataAnnotations;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.Domain.Clients
{
    public class Client
    {
        [BindNever]
        public int ClientId { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }

        [Required(ErrorMessage = "First name must be entered")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name must be entered")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "ISP Start Date")]
        public DateOnly ISP_YearStartDate { get; set; }

        [Required]
        [Display(Name = "Severity")]
        public bool IsSevere { get; set; }

        [Required]
        [Display(Name = "Needs BCIP")]
        public bool NeedsBCIP { get; set; }

        [Required]
        [Display(Name = "Needs PPMP")]
        public bool NeedsPPMP { get; set; }

        public List<ISP_Year> ISP_Years { get; set; } = new List<ISP_Year>();
    }
}