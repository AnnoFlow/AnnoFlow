namespace AnnoFlow.Core.Entities
{
    public class Annotation : IIdentifiable
    {
        public Guid Id { get; set; }

        public Guid DatasetId { get; set; }
    }
}