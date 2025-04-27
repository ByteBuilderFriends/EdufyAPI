using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public static class EnrollmentSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Replace with actual seeded Student IDs from RoleSeeding
            var student1Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77";
            var student2Id = "e452e625-327a-4bf2-9540-3db6577ab68f";

            // Replace with actual seeded Course IDs from CourseSeeding
            var q1 = "q1";
            var q2 = "q2";

            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = student1Id,
                    CourseId = q1
                },
                new Enrollment
                {
                    StudentId = student1Id,
                    CourseId = q2
                },
                new Enrollment
                {
                    StudentId = student2Id,
                    CourseId = q1
                },
                new Enrollment
                {
                    StudentId = student2Id,
                    CourseId = q2
                }
            };

            modelBuilder.Entity<Enrollment>().HasData(enrollments);
        }
    }
}
