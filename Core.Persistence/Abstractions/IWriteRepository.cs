namespace Core.Persistence.Abstractions;

public interface IWriteRepository<T> : IReadRepository<T> where T : class
{
	void Add(T employee);
	void Update(T employee);
}