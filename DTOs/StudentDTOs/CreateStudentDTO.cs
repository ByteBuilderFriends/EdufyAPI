using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.StudentDTOs
{
    public class CreateStudentDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password Must Match")]
        public string ConfirmPassword { get; set; }
    }
}
