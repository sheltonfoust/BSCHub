using System.ComponentModel.DataAnnotations;

namespace SocialWorkApp.MVC.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "First name must be entered")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name must be entered")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = String.Empty;
        public bool IsProvider { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsIndependent { get; set; }
    }
}
