using EduConnectAPI.Models;
using EdufyAPI.Models.Roles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Models
{
    public partial class AppDbContext : IdentityDbContext<AppUser>
    {
        #region DbSets
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<StudentAnswer> StudentAnswer { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Certificate> Certificate { get; set; }

        #endregion
    }
}
