using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EdufyAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        // ✅ Inject `AppDbContext` correctly
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); // ✅ Set the correct DbSet
        }

        // ✅ Return `IReadOnlyList<T>` for safety
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Get a list by a condition
        public async Task<IReadOnlyList<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        // Get a single field by a condition
        public async Task<T?> GetSingleByCondition(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        //Delete by id
        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete by id
        public async Task<bool> DeleteAsync(string Fid, string Sid)
        {
            var entity = await _dbSet.FindAsync(Fid, Sid);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        //Delete by object
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        //Enrollment only

        public async Task<Enrollment?> GetAsync(string studentId, string courseId)
        {
            return await _context.Enrollment
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }
    }
}

