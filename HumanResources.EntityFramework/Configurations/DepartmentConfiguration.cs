using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using HumanResources.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.EntityFramework.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
	public void Configure(EntityTypeBuilder<Department> builder)
	{
		builder.HasKey(x => x.Id);
		// builder
		// 	.HasDiscriminator<string>("EmployeeType")
		// 	.HasValue<RegularEmployee>("Regular")
		// 	.HasValue<AdministrativeEmployee>("Administrative")
		// 	.HasValue<Professor>("Professor");

		builder.Property(x => x.Id)
			.HasConversion<EntityIdentityConverter<DepartmentId, Guid>>()
			.ValueGeneratedOnAdd();

		builder.Property(x => x.Name).HasConversion<SingleNameConverter>();
	}
}
