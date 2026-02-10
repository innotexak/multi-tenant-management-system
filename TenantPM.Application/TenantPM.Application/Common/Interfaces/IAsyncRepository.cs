using System.Linq.Expressions;

namespace TenantPM.Application.Common.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task<T>  UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task<T>  RemoveAsync(T entity, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);
    }
}
