using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.Models.Roles
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email or Username")]
        public string Email { get; set; }


    }
}
