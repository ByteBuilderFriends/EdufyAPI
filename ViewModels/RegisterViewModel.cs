using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email or Username")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }


        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }


        // will be implemented in the future
        //[Display(Name = "Profile Picture")]
        //public IFormFile ProfilePicture { get; set; }


    }
}
