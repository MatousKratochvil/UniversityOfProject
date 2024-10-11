namespace Core.Persistence.Abstractions;

public interface IEntityIdentity<out T>
{
	T Id { get; }
}

public interface IEntity<out T, TKey> where T : IEntityIdentity<TKey>
{
	T Id { get; }
}