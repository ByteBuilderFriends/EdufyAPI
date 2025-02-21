using EdufyAPI.Models;

namespace EdufyAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Course> CourseRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
