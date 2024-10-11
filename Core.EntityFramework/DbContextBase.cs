using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public abstract class DbContextBase(DbContextOptions options) : DbContext(options)
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		ConfigureContext(modelBuilder);
	}

	protected abstract void ConfigureContext(ModelBuilder configurationBuilder);
}