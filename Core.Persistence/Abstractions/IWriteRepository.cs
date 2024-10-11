namespace Core.Persistence.Abstractions;

public interface IWriteRepository<in T> where T : class
{
	void Add(T employee);
}