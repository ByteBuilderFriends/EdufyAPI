using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class ProgressSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var student1Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77";
            var student2Id = "e452e625-327a-4bf2-9540-3db6577ab68f";

            var q1 = "q1";
            var q2 = "q2";

            var fixedDate = new DateTime(2025, 4, 7, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Progress>().HasData(
                new Progress
                {
                    Id = "PROG-1001",
                    CourseId = q1,
                    StudentId = student1Id,
                    TotalLessonsCompleted = 5,
                    LastUpdated = fixedDate
                },
                new Progress
                {
                    Id = "PROG-1002",
                    CourseId = q1,
                    StudentId = student2Id,
                    TotalLessonsCompleted = 7,
                    LastUpdated = fixedDate
                },
                new Progress
                {
                    Id = "PROG-1003",
                    CourseId = q2,
                    StudentId = student1Id,
                    TotalLessonsCompleted = 10,
                    LastUpdated = fixedDate
                },
                new Progress
                {
                    Id = "PROG-1004",
                    CourseId = q2,
                    StudentId = student2Id,
                    TotalLessonsCompleted = 12,
                    LastUpdated = fixedDate
                }
            );
        }
    }
}
