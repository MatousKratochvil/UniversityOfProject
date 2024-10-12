using Core.EntityFramework;
using Core.Persistence.Abstractions;
using HumanResources.Abstractions;
using HumanResources.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HumanResources.EntityFramework;

internal class HumanResourcesContext(DbContextOptions options) : DbContextBase(options), IHumanResourcesDbContext
{
	internal DbSet<Employee> EmployeesSet { get; set; }

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
	}

	public IWriteRepository<Employee> Employees => new WriteRepository<Employee>(EmployeesSet);

	public IReadRepository<Employee> ReadEmployees => new ReadRepository<Employee>(
		EmployeesSet
			.Include(x => x.Contract)
			.ThenInclude(x => x.Department));

	public void AddEntity<TEntity>(TEntity entity) where TEntity : class => Add(entity);

	protected override void ConfigureContext(ModelBuilder configurationBuilder) =>
		configurationBuilder.ApplyConfigurationsFromAssembly(typeof(HumanResourcesContext).Assembly);
}

internal class HumanResourcesContextFactory : IDesignTimeDbContextFactory<HumanResourcesContext>
{
	public HumanResourcesContext CreateDbContext(string[] args)
	{
		var options = new DbContextOptionsBuilder<HumanResourcesContext>()
			.UseSqlite("Data Source=DesignTimeDbContextFactory.db")
			.Options;

		return new HumanResourcesContext(options);
	}
}