using AnnoFlow.Core.Entities;

namespace AnnoFlow.Core.Persistence
{
    public interface IDatasetsRepository : IRepository<Guid, Dataset>
    {
    }
}