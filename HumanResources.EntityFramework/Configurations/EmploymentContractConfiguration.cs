﻿using Core.EntityFramework;
using Core.EntityFramework.Common;
using HumanResources.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.EntityFramework.Configurations;

public class EmploymentContractConfiguration : IEntityTypeConfiguration<EmploymentContract>
{
	public void Configure(EntityTypeBuilder<EmploymentContract> builder)
	{
		builder.HasKey(x => x.Id);
		builder
			.HasDiscriminator<string>("ContractType")
			.HasValue<PermanentContract>("Permanent")
			.HasValue<TemporaryContract>("Temporary");

		builder.Property(x => x.Id)
			.HasConversion<EntityIdentityConverter<EmploymentContractId, Guid>>()
			.ValueGeneratedOnAdd();
		
		builder.HasOne(x => x.Employee)
			.WithOne(x => x.Contract)
			.HasForeignKey<EmploymentContract>(x => x.EmployeeId);

		builder.HasOne(x => x.Department)
			.WithOne()
			.HasForeignKey<EmploymentContract>(x => x.DepartmentId);

		builder.ComplexProperty(x => x.Period).Configure(new PeriodConfiguration());
	}
}