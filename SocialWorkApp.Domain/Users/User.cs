using System.ComponentModel.DataAnnotations;

namespace BSCHub.Domain.Users
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name must be entered")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name must be entered")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Is Provider")]
        public bool IsConsultant { get; set; }
        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Is Independent")]
        public bool IsIndependent { get; set; }

    }
}
