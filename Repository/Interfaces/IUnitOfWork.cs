using EduConnectAPI.Models;
using EdufyAPI.Models;
using EdufyAPI.Models.Roles;

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
        GenericRepository<QuizResult> QuizResultRepository { get; }
        GenericRepository<Question> QuestionRepository { get; }
        GenericRepository<Answer> AnswerRepository { get; }
        GenericRepository<StudentAnswer> StudentAnswerRepository { get; }


        Task<int> SaveChangesAsync();
    }
}
