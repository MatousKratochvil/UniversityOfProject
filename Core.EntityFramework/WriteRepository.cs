using Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class WriteRepository<TEntity>(DbSet<TEntity> dbSet) : IWriteRepository<TEntity> where TEntity : class
{
	public void Add(TEntity employee) => dbSet.Add(employee);
}