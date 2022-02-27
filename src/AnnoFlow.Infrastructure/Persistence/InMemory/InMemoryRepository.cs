using AnnoFlow.Core.Entities;
using AnnoFlow.Core.Persistence;

namespace AnnoFlow.Infrastructure.Persistence.InMemory
{
    public abstract class InMemoryRepository<T, TId> : IRepository<T, TId>
        where TId : IEquatable<TId>
        where T : IPersistentEntity<TId>
    {
        protected Dictionary<TId, T> Store { get; }

        protected InMemoryRepository()
        {
            Store = new Dictionary<TId, T>();
        }

        protected InMemoryRepository(Dictionary<TId, T> store)
        {
            Store = store;
        }

        public Task DeleteAsync(T item)
        {
            Store.Remove(item.Id);

            return Task.CompletedTask;
        }

        public Task<T?> FindAsync(TId id)
        {
            if (Store.TryGetValue(id, out var item))
            {
                return Task.FromResult<T?>(item);
            }

            return Task.FromResult(default(T?));
        }

        public Task InsertAsync(T item)
        {
            Store[item.Id] = item;

            return Task.CompletedTask;
        }

        public Task ReplaceAsync(T item)
        {
            Store[item.Id] = item;

            return Task.CompletedTask;
        }
    }
}