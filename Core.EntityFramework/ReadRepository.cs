using Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class ReadRepository<TEntity>(IQueryable<TEntity> baseQuery) : IReadRepository<TEntity> where TEntity : class
{
	private readonly IQueryable<TEntity> _baseQuery = baseQuery.AsNoTracking();
	public IQueryable<TEntity> Query() => _baseQuery;
}