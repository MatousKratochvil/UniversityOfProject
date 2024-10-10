namespace Core.Persistence.Abstractions;

public interface IEntityIdentity<out T>
{
    T Id { get; }
}