namespace AnnoFlow.Core.Entities
{
    public class Dataset : IPersistentEntity<Guid>, IVersionable
    {
        public Dataset(Guid id, Version datasetVersion)
        {
            Id = id;
            Version = datasetVersion;
        }

        public Guid Id { get; init; }

        public Version Version { get; init; }
    }
}