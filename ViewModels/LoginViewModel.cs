using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email or Username")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
