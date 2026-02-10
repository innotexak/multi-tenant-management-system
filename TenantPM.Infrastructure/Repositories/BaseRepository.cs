using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TenantPM.Application.Common.Interfaces;

namespace TenantPM.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var result = await _dbSet.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<T> RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
