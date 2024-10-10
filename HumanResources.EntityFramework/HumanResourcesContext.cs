using Core.EntityFramework;
using Core.Persistence.Abstractions;
using HumanResources.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.EntityFramework;

internal class HumanResourcesContext : DbContext, IHumanResourcesDbContext
{
    internal DbSet<Employee> EmployeesSet { get; set; }
    internal DbSet<AdministrativeEmployee> AdministrativeEmployeesSet { get; set; }
    internal DbSet<Professor> ProfessorsSet { get; set; }

    public IWriteRepository<Employee> Employees => new WriteRepository<Employee>(EmployeesSet);
    public IReadRepository<Employee> ReadEmployees => new ReadRepository<Employee>(EmployeesSet);

    public IWriteRepository<AdministrativeEmployee> AdministrativeEmployees =>
        new WriteRepository<AdministrativeEmployee>(AdministrativeEmployeesSet);

    public IReadRepository<AdministrativeEmployee> ReadAdministrativeEmployees =>
        new ReadRepository<AdministrativeEmployee>(AdministrativeEmployeesSet);

    public IWriteRepository<Professor> Professors => new WriteRepository<Professor>(ProfessorsSet);
    public IReadRepository<Professor> ReadProfessors => new ReadRepository<Professor>(ProfessorsSet);
}