using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email or Username")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
