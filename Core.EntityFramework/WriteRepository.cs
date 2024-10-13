using Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class WriteRepository<TEntity, TKey, TType>(DbSet<TEntity> dbSet, IQueryable<TEntity> baseQuery)
	: IWriteRepository<TEntity> where TEntity : class, IEntity<TKey, TType> where TKey : IEntityIdentity<TType>
{
	public IQueryable<TEntity> Query() => baseQuery;
	public void Add(TEntity employee) => dbSet.Add(employee);

	public void Update(TEntity employee)
	{
		var foundEmployee = dbSet.Find(employee.Id);
		if (foundEmployee == null)
			throw new InvalidOperationException("Entity not found in the database");
		dbSet.Entry(foundEmployee).CurrentValues.SetValues(employee);
	}
}