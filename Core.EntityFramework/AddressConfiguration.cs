using Core.CompositeValueObjects;
using Core.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class AddressConfiguration : IComplexPropertyConfiguration<Address>
{
    public ComplexPropertyBuilder<Address> Configure(ComplexPropertyBuilder<Address> builder)
    {
        builder.Property(x => x.Street)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.ZipCode)
            .HasMaxLength(10)
            .IsRequired();

        return builder;
    }
}