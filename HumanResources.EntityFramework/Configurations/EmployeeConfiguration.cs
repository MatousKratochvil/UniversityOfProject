using Core.EntityFramework;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
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
        
        builder.Property(x => x.Id).HasConversion<EntityIdentityConverter<EmployeeId, Guid>>();
        builder.Property(x => x.EmployeeNumber).HasConversion<EmployeeNumberConverter>();
        builder.ComplexProperty(x => x.Name).Configure(new PersonNameConfiguration());
        builder.ComplexProperty(x => x.Address).Configure(new AddressConfiguration());
        builder.ComplexProperty(x => x.ContactInformation).Configure(new ContactInformationConfiguration());
    }
}