using AnnoFlow.Core.Entities;

namespace AnnoFlow.Core.Persistence
{
    public interface IRepository<T, TId>
        where TId : IEquatable<TId>
        where T : IPersistentEntity<TId>
    {
        Task DeleteAsync(T item);

        Task<T?> FindAsync(TId id);

        Task InsertAsync(T item);

        Task ReplaceAsync(T item);
    }
}