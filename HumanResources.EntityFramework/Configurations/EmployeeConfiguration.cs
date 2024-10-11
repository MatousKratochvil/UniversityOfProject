using Core.EntityFramework;
using Core.EntityFramework.Common;
using HumanResources.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.EntityFramework.Configurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasDiscriminator<string>("EmployeeType")
            .HasValue<RegularEmployee>("Regular")
            .HasValue<AdministrativeEmployee>("Administrative")
            .HasValue<Professor>("Professor");

        builder.Property(x => x.Id)
            .HasConversion<EntityIdentityConverter<EmployeeId, Guid>>()
            .ValueGeneratedOnAdd();

        builder.ComplexProperty(x => x.Person).Configure(new PersonConfiguration());
    }
}