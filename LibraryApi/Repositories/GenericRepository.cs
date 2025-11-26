using LibraryApi.Model;
using Microsoft.EntityFrameworkCore;
using LibraryApi.Data;
using LibraryApi.Repositories.Interfaces;

namespace LibraryApi.Repositories.Interface
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly LibraryApiDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(LibraryApiDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public virtual void Update(T entity) => _dbSet.Update(entity);

        public virtual void Delete(T entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public virtual async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}