using EduConnectAPI.Models;
using EdufyAPI.Models;
using EdufyAPI.Models.Roles;
using EdufyAPI.Repository.Interfaces;

namespace EdufyAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) => _context = context;


        private GenericRepository<Course> _courseRepository;
        private GenericRepository<Lesson> _lessonRepository;
        private GenericRepository<Progress> _progressRepository;
        private GenericRepository<Quiz> _quizRepository;
        private GenericRepository<Question> _questionRepository;
        private GenericRepository<Answer> _answerRepository;
        private GenericRepository<QuizResult> _quizResultRepository;
        private GenericRepository<StudentAnswer> _studentAnswerRepository;
        private GenericRepository<Certificate> _certificateRepository;
        private GenericRepository<Admin> _adminRepository;
        private GenericRepository<Student> _studentRepository;
        private GenericRepository<Instructor> _instructorRepository;
        private GenericRepository<Enrollment> _enrollmentRepository;


        #region Repositories
        // Add your repositories here, assign Geters
        #region example
        /*    public GenericRepository<Book> BookRepo
        {
            get
            {
                if (BookRepository == null)
                    BookRepository = new GenericRepository<Book>(_context);
                return BookRepository;
            }
        }



        */
        #endregion
        public GenericRepository<Course> CourseRepository => _courseRepository ??= new GenericRepository<Course>(_context);
        public GenericRepository<Lesson> LessonRepository => _lessonRepository ??= new GenericRepository<Lesson>(_context);
        public GenericRepository<Progress> ProgressRepository => _progressRepository ??= new GenericRepository<Progress>(_context);
        public GenericRepository<Quiz> QuizRepository => _quizRepository ??= new GenericRepository<Quiz>(_context);
        public GenericRepository<Question> QuestionRepository => _questionRepository ??= new GenericRepository<Question>(_context);
        public GenericRepository<Answer> AnswerRepository => _answerRepository ??= new GenericRepository<Answer>(_context);
        public GenericRepository<QuizResult> QuizResultRepository => _quizResultRepository ??= new GenericRepository<QuizResult>(_context);
        public GenericRepository<StudentAnswer> StudentAnswerRepository => _studentAnswerRepository ??= new GenericRepository<StudentAnswer>(_context);
        public GenericRepository<Certificate> CertificateRepository => _certificateRepository ??= new GenericRepository<Certificate>(_context);
        public GenericRepository<Admin> AdminRepository => _adminRepository ??= new GenericRepository<Admin>(_context);
        public GenericRepository<Student> StudentRepository => _studentRepository ??= new GenericRepository<Student>(_context);
        public GenericRepository<Instructor> InstructorRepository => _instructorRepository ??= new GenericRepository<Instructor>(_context);
        public GenericRepository<Enrollment> EnrollmentRepository => _enrollmentRepository ??= new GenericRepository<Enrollment>(_context);

        #endregion

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
