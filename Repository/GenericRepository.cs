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
            // Check if the entity is null before proceeding
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }

            try
            {
                // Get the entry for the entity to check its state
                var entry = _context.Entry(entity);

                // If the entity is not being tracked (detached), attach it to the context
                if (entry.State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                // Remove the entity from the DbSet, marking it for deletion
                _dbSet.Remove(entity);

                // Save the changes to the database asynchronously
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Catch any exception that occurs and wrap it in a new exception with a custom message
                throw new Exception("An error occurred while deleting the entity", ex);
            }
        }


        //Enrollment only
        public async Task<Enrollment?> GetAsync(string studentId, string courseId)
        {
            return await _context.Enrollment
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }

        // ✅ Bulk Add
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

        }
        // ✅ Bulk Delete
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChangesAsync();
        }

        // CountAsync
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }
    }
}

