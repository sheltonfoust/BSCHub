using Microsoft.AspNetCore.Mvc.ModelBinding;
using BSCHub.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace BSCHub.Domain.Clients
{
    public class Client
    {

        public int ClientId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required(ErrorMessage = "First name must be entered")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name must be entered")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

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
    
        public string GetName()
        {
            return FirstName + " " + LastName;
        }
    }
}