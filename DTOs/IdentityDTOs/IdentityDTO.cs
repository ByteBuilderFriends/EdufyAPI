using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.IdentityDTOs
{
    public class UpdateEmailDTO
    {
        public string UserId { get; set; }

        [Required]
        public string NewEmail { get; set; }
    }

    public class UpdatePasswordDTO
    {
        public string UserId { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required, MinLength(6)]
        public string NewPassword { get; set; }
    }

    public class UpdateNameDTO
    {
        public string UserId { get; set; }

        [Required, MinLength(2)]
        public string FirstName { get; set; }

        [Required, MinLength(2)]
        public string LastName { get; set; }
    }

}
