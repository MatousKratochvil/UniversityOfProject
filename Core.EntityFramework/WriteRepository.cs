using Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class WriteRepository<TEntity>(DbSet<TEntity> dbSet, IQueryable<TEntity> baseQuery) : IWriteRepository<TEntity> where TEntity : class
{
	public IQueryable<TEntity> Query() => baseQuery;
	public void Add(TEntity employee) => dbSet.Add(employee);
	public void Update(TEntity employee) => dbSet.Update(employee);
}