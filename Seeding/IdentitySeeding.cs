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
                        PasswordHash = "AQAAAAIAAYagAAAAEKsmLRBJp6I5tKPy0WDNs07ql09VZX8z4DGjbn3fzmT2LbzkPQnDg7czDSEiGsR3PA==",
                        PhoneNumber = "1234567890",
                        ConcurrencyStamp = "fixed-concurrency-stamp-1",
                        SecurityStamp = "fixed-security-stamp-1"
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
                        PasswordHash = "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==",
                        PhoneNumber = "0987654321",
                        ConcurrencyStamp = "fixed-concurrency-stamp-2",
                        SecurityStamp = "fixed-security-stamp-2"
                    }
                };

            // Seed instructors
            var instructors = new List<Instructor>
                {
                new Instructor
                {
                    Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd66",
                    FirstName = "AskAMuslim",
                    LastName = "Academy",
                    Email = "aam@example.com",
                    NormalizedEmail = "AAM@EXAMPLE.COM",
                    UserName = "aam",
                    NormalizedUserName = "AAM",
                    PasswordHash = "AQAAAAIAAYagAAAAEKsmLRBJp6I5tKPy0WDNs07ql09VZX8z4DGjbn3fzmT2LbzkPQnDg7czDSEiGsR3PA==",
                    PhoneNumber = "1234567890",
                    ConcurrencyStamp = "fixed-concurrency-stamp-1",
                    SecurityStamp = "fixed-security-stamp-1"
                },
                new Instructor
                {
                    Id = "7d3f2475-7a1b-4f85-92eb-0faab6aa8d4f",
                    FirstName = "Marwan",
                    LastName = "Mohamed",
                    Email = "marwan.mohamed@example.com",
                    NormalizedEmail = "MARWAN.MOHAMED@EXAMPLE.COM",
                    UserName = "marwan.mohamed",
                    NormalizedUserName = "MARWAN.MOHAMED",
                    PasswordHash = "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==",
                    PhoneNumber = "0987654321",
                    ConcurrencyStamp = "fixed-concurrency-stamp-2",
                    SecurityStamp = "fixed-security-stamp-2"
                },
                new Instructor
                {
                    Id = "9a5c21b2-2d92-4d0f-bad3-47d4bbd4e611",
                    FirstName = "Mujahid",
                    LastName = "Hussain",
                    Email = "mujahid.hussain@example.com",
                    NormalizedEmail = "MUJAHID.HUSSAIN@EXAMPLE.COM",
                    UserName = "mujahid.hussain",
                    NormalizedUserName = "MUJAHID.HUSSAIN",
                    PasswordHash = "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==",
                    PhoneNumber = "0987654321",
                    ConcurrencyStamp = "fixed-concurrency-stamp-3",
                    SecurityStamp = "fixed-security-stamp-3"
                },
                new Instructor
                {
                    Id = "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29",
                    FirstName = "Mufti",
                    LastName = "Menk",
                    Email = "mufti.menk@example.com",
                    NormalizedEmail = "MUFTI.MENK@EXAMPLE.COM",
                    UserName = "mufti.menk",
                    NormalizedUserName = "MUFTI.MENK",
                    PasswordHash = "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==",
                    PhoneNumber = "0987654321",
                    ConcurrencyStamp = "fixed-concurrency-stamp-4",
                    SecurityStamp = "fixed-security-stamp-4"
                },
                new Instructor
                {
                    Id = "d1234567-89ab-4cde-8f01-23456789abcd",
                    FirstName = "Assim",
                    LastName = "AlHakeem",
                    Email = "assim.alhakeem@example.com",
                    NormalizedEmail = "ASSIM.ALHAKEEM@EXAMPLE.COM",
                    UserName = "assim.alhakeem",
                    NormalizedUserName = "ASSIM.ALHAKEEM",
                    PasswordHash = "AQAAAAIAAYagAAAAEB1wXcGz8Hbl5otx+fN7ygtlzHv2NfqeUqlg3RW0dP4gWbTY6wHT0t8xKzJKzZfyDQ==",
                    PhoneNumber = "0123456789",
                    ConcurrencyStamp = "fixed-concurrency-stamp-5",
                    SecurityStamp = "fixed-security-stamp-5"
                },
                new Instructor
                {
                    Id = "f2345678-90ab-4def-9f12-34567890bcde",
                    FirstName = "Muhammad",
                    LastName = "Salah",
                    Email = "muhammad.salah@example.com",
                    NormalizedEmail = "MUHAMMAD.SALAH@EXAMPLE.COM",
                    UserName = "muhammad.salah",
                    NormalizedUserName = "MUHAMMAD.SALAH",
                    PasswordHash = "AQAAAAIAAYagAAAAEC9oZk+QkS2u4GNHbAh9uPuBjNQfHdjkk5IvP8xCmUNz5cIY3ZoIXF1xv8bZf9nqBA==",
                    PhoneNumber = "0112233445",
                    ConcurrencyStamp = "fixed-concurrency-stamp-6",
                    SecurityStamp = "fixed-security-stamp-6"
                },
                new Instructor
                {
                    Id = "a3456789-01bc-4fgh-9g23-45678901cdef",
                    FirstName = "Ibn",
                    LastName = "Uthaymeen",
                    Email = "ibn.uthaymeen@example.com",
                    NormalizedEmail = "IBN.UTHAYMEEN@EXAMPLE.COM",
                    UserName = "ibn.uthaymeen",
                    NormalizedUserName = "IBN.UTHAYMEEN",
                    PasswordHash = "AQAAAAIAAYagAAAAEDh4wGZKpAbvIJKliK8GLUUSUrfz1D7ySMf9IFXGwG3o8fR9cA7ek/5yk8QbMv9iyA==",
                    PhoneNumber = "0223344556",
                    ConcurrencyStamp = "fixed-concurrency-stamp-7",
                    SecurityStamp = "fixed-security-stamp-7"
                },
                new Instructor
                {
                    Id = "b4567890-12cd-5ghi-0h34-56789012def0",
                    FirstName = "Ibn",
                    LastName = "Farooq",
                    Email = "ibn.farooq@example.com",
                    NormalizedEmail = "IBN.FAROOQ@EXAMPLE.COM",
                    UserName = "ibn.farooq",
                    NormalizedUserName = "IBN.FAROOQ",
                    PasswordHash = "AQAAAAIAAYagAAAAEDy4zHzmVDpQm3uvHQclPBfiD/NvWb8IlA6tbjdzGp5B0V5RBoTxAjB4vKnV8qvG8w==",
                    PhoneNumber = "0334455667",
                    ConcurrencyStamp = "fixed-concurrency-stamp-8",
                    SecurityStamp = "fixed-security-stamp-8"
                },
                new Instructor
                {
                    Id = "b4567890-12cd-5ghi-0h34-56789012def1",
                    FirstName = "Zad",
                    LastName = "Academy",
                    Email = "zad.academy@example.com",
                    NormalizedEmail = "ZAD.ACADEMY@EXAMPLE.COM",
                    UserName = "zad.academy",
                    NormalizedUserName = "ZAD.ACADEMY",
                    PasswordHash = "AQAAAAIAAYagAAAAEDy4zHzmVDpQm3uvHQclPBfiD/NvWb8IlA6tbjdzGp5B0V5RBoTxAjB4vKnV8qvG8w==",
                    PhoneNumber = "0334455667",
                    ConcurrencyStamp = "fixed-concurrency-stamp-9",
                    SecurityStamp = "fixed-security-stamp-9"
                }
                };

            // Seed each entity separately
            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Instructor>().HasData(instructors);
        }
    }
}
