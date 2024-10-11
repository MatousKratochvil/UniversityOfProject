using Core.Persistence.Abstractions;
using HumanResources.Entities;

namespace HumanResources.Abstractions;

internal interface IHumanResourcesDbContext
{
    IWriteRepository<Employee> Employees { get; }
    IReadRepository<Employee> ReadEmployees { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}