using EduConnectAPI.Models;
using EdufyAPI.Models;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Models.Roles;
using Microsoft.EntityFrameworkCore.Storage;

namespace EdufyAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Admin> AdminRepository { get; }
        GenericRepository<Instructor> InstructorRepository { get; }
        GenericRepository<Student> StudentRepository { get; }
        GenericRepository<Course> CourseRepository { get; }
        GenericRepository<Lesson> LessonRepository { get; }
        GenericRepository<Progress> ProgressRepository { get; }
        GenericRepository<Certificate> CertificateRepository { get; }
        GenericRepository<Quiz> QuizRepository { get; }
        GenericRepository<QuizAttemp> QuizAttempRepository { get; }
        GenericRepository<Question> QuestionRepository { get; }
        GenericRepository<Answer> AnswerRepository { get; }
        GenericRepository<StudentAnswer> StudentAnswerRepository { get; }
        GenericRepository<Enrollment> EnrollmentRepository { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> SaveChangesAsync();
    }
}
