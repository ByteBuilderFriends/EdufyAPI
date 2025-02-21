using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.Models.Roles
{
    public class Student : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginTime { get; set; }
        public int FailedLoginAttempts { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        #region Relationships
        // List of courses the student is enrolled in
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>(); // Many-to-Many
        #endregion

    }
}