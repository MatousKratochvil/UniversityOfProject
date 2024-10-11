namespace Core.Persistence.Abstractions;

public interface IReadRepository<out T> where T : class
{
    IQueryable<T> Query();
}
    