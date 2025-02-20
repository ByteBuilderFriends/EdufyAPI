using Microsoft.AspNetCore.Identity;

namespace EdufyAPI.Models.Roles
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginTime { get; set; }
        public int FailedLoginAttempts { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // Role & Claims
        public virtual ICollection<IdentityUserClaim<string>> UserClaims { get; set; } = new List<IdentityUserClaim<string>>();
    }
}
