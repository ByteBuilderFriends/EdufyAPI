using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    public class Enrollment
    {
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}