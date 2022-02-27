namespace AnnoFlow.Core.Entities
{
    public class Annotation : IPersistentEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid DatasetId { get; set; }
    }
}