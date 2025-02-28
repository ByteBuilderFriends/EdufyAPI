using EdufyAPI.Models;

namespace EdufyAPI.Repository.Interfaces
{
    internal interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);

        // Enrollment only
        Task<Enrollment?> GetAsync(string studentId, string courseId);
        //Task<bool> SaveChangesAsync();
    }
}