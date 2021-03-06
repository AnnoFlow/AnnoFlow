namespace AnnoFlow.Core.Entities
{
    public interface IIdentifiable<T>
        where T : IEquatable<T>
    {
        T Id { get; }
    }
}