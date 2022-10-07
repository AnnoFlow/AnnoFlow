using AnnoFlow.Core.Entities;
using AnnoFlow.Core.Persistence;

namespace AnnoFlow.Infrastructure.Persistence.InMemory
{
    public abstract class InMemoryRepository<TId, TValue> : IRepository<TId, TValue>
        where TId : IEquatable<TId>
        where TValue : IPersistentEntity<TId>
    {
        protected Dictionary<TId, TValue> Store { get; }

        protected InMemoryRepository()
        {
            Store = new Dictionary<TId, TValue>();
        }

        protected InMemoryRepository(Dictionary<TId, TValue> store)
        {
            Store = store;
        }

        public Task DeleteAsync(TValue item)
        {
            Store.Remove(item.Id);

            return Task.CompletedTask;
        }

        public Task<TValue?> FindAsync(TId id)
        {
            if (Store.TryGetValue(id, out var item))
            {
                return Task.FromResult<TValue?>(item);
            }

            return Task.FromResult(default(TValue?));
        }

        public Task InsertAsync(TValue item)
        {
            Store[item.Id] = item;

            return Task.CompletedTask;
        }

        public Task ReplaceAsync(TValue item)
        {
            Store[item.Id] = item;

            return Task.CompletedTask;
        }
    }
}