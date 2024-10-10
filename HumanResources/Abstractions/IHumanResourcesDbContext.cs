using Core.Persistence.Abstractions;

namespace HumanResources.Abstractions;

internal interface IHumanResourcesDbContext
{
    IWriteRepository<Employee> Employees { get; }
    IReadRepository<Employee> ReadEmployees { get; }

    IWriteRepository<AdministrativeEmployee> AdministrativeEmployees { get; }
    IReadRepository<AdministrativeEmployee> ReadAdministrativeEmployees { get; }

    IWriteRepository<Professor> Professors { get; }
    IReadRepository<Professor> ReadProfessors { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}