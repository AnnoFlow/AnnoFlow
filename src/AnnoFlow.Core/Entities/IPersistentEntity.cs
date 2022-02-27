namespace AnnoFlow.Core.Entities
{
    public interface IPersistentEntity<T> : IIdentifiable<T>
        where T : IEquatable<T>
    {
    }
}