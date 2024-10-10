using Core.Persistence.Abstractions;

namespace HumanResources.Abstractions;

internal interface IHumanResourcesDbContext
{
    IWriteRepository<Employee> Employees { get; set; }
    IReadRepository<Employee> ReadEmployees { get; set; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
