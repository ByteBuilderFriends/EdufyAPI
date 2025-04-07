using EdufyAPI.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public static class IdentitySeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<AppUser>();

            // Seed students
            var students = new List<Student>
            {
                new Student
                {
                    Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                    FirstName = "Ali",
                    LastName = "Mahmoud",
                    Email = "ali.mahmoud@example.com",
                    NormalizedEmail = "ALI.MAHMOUD@EXAMPLE.COM",
                    UserName = "ali.mahmoud",
                    NormalizedUserName = "ALI.MAHMOUD",
                    PasswordHash = hasher.HashPassword(null, "Student@123"),
                    PhoneNumber = "1234567890",
                },
                new Student
                {
                    Id = "e452e625-327a-4bf2-9540-3db6577ab68f",
                    FirstName = "Salma",
                    LastName = "Ahmed",
                    Email = "salma.ahmed@example.com",
                    NormalizedEmail = "SALMA.AHMED@EXAMPLE.COM",
                    UserName = "salma.ahmed",
                    NormalizedUserName = "SALMA.AHMED",
                    PasswordHash = hasher.HashPassword(null, "Student@123"),
                    PhoneNumber = "0987654321",
                }
            };

            // Seed instructors
            var instructors = new List<Instructor>
            {
                new Instructor
                {
                    Id = "58ec4bbf-4913-4dc1-96b7-381159ce0878",
                    FirstName = "Omar",
                    LastName = "Tarek",
                    Email = "omar.tarek@example.com",
                    NormalizedEmail = "OMAR.TAREK@EXAMPLE.COM",
                    UserName = "omar.tarek",
                    NormalizedUserName = "OMAR.TAREK",
                    PasswordHash = hasher.HashPassword(null, "Instructor@123"),
                    PhoneNumber = "1122334455",
                },
                new Instructor
                {
                    Id = "a86582e6-8511-4b78-b548-e17a2eaf0d3e",
                    FirstName = "Hana",
                    LastName = "Mostafa",
                    Email = "hana.mostafa@example.com",
                    NormalizedEmail = "HANA.MOSTAFA@EXAMPLE.COM",
                    UserName = "hana.mostafa",
                    NormalizedUserName = "HANA.MOSTAFA",
                    PasswordHash = hasher.HashPassword(null, "Instructor@123"),
                    PhoneNumber = "5566778899",
                }
            };

            // Seed each entity separately
            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Instructor>().HasData(instructors);
        }
    }
}
