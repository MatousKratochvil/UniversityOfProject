using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using HumanResources.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HumanResources.EntityFramework;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
	}

	public DbSet<Employee> Employees { get; set; }
}

internal class DesignTimeContextFactory : IDesignTimeDbContextFactory<Context>
{
	public Context CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<Context>();
		optionsBuilder.UseSqlite("Data Source=../HumanResources.db");

		return new Context(optionsBuilder.Options);
	}
}