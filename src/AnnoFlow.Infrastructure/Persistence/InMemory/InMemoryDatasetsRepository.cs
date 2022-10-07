using AnnoFlow.Core.Entities;
using AnnoFlow.Core.Persistence;

namespace AnnoFlow.Infrastructure.Persistence.InMemory
{
    public class InMemoryDatasetsRepository : InMemoryRepository<Guid, Dataset>, IDatasetsRepository
    {
    }
}