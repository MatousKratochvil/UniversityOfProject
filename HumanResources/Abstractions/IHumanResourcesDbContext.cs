using Core.Persistence.Abstractions;
using HumanResources.Entities;

namespace HumanResources.Abstractions;

internal interface IHumanResourcesDbContext
{
	IWriteRepository<Employee> Employees { get; }
	IReadRepository<Employee> ReadEmployees { get; }

	void AddEntity<TEntity>(TEntity entity) where TEntity : class;
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}