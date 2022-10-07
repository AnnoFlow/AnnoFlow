using AnnoFlow.Core.Entities;

namespace AnnoFlow.Core.Persistence
{
    public interface IRepository<TId, TValue>
        where TId : IEquatable<TId>
        where TValue : IPersistentEntity<TId>
    {
        Task DeleteAsync(TValue item);

        Task<TValue?> FindAsync(TId id);

        Task InsertAsync(TValue item);

        Task ReplaceAsync(TValue item);
    }
}