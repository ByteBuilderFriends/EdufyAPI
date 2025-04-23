using AskAMuslimAPI.Enums;
using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class CourseSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Fetching existing instructor IDs from RoleSeeding
            var instructor1Id = "58ec4bbf-4913-4dc1-96b7-381159ce0878"; // Replace with the actual ID from RoleSeeding
            var instructor2Id = "a86582e6-8511-4b78-b548-e17a2eaf0d3e"; // Replace with the actual ID from RoleSeeding

            var courses = new List<Course>
            {
                new Course
                {
                    Id = "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                    Title = "Introduction to C#",
                    Description = "Learn the basics of C# programming, including syntax, OOP concepts, and best practices.",
                    Category = CourseCategory.QuranMemorization,
                    ThumbnailUrl = "csharp_course_thumbnail.jpg",
                    InstructorId = instructor1Id
                },
                new Course
                {
                    Id = "2d7df053-81d5-4bb8-994d-76619c341c46",
                    Title = "Advanced .NET Development",
                    Description = "Deep dive into .NET framework, dependency injection, middleware, and microservices.",
                    Category = CourseCategory.Other,
                    ThumbnailUrl = "dotnet_course_thumbnail.jpg",
                    InstructorId = instructor2Id
                }
            };

            modelBuilder.Entity<Course>().HasData(courses);
        }
    }
}
