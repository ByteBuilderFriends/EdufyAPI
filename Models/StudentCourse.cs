using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
