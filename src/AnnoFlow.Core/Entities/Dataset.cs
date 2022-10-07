namespace AnnoFlow.Core.Entities
{
    public class Dataset : IPersistentEntity<Guid>
    {
        public Dataset(Guid id, Version version)
        {
            Id = id;
            Version = version;
        }

        public Guid Id { get; init; }

        public Version Version { get; init; }
    }
}