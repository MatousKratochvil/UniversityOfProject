using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using HumanResources.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.EntityFramework;

public class EmployeesConfig : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.HasKey(e => e.Id);
		builder.Property(e => e.Id).ValueGeneratedOnAdd();
		builder.ComplexProperty(e => e.PersonalInformation).Configure(new PersonalInformationConfiguration());
	}
}