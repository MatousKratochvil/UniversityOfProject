using Core.CompositeValueObjects;
using Core.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class PersonNameConfiguration : IComplexPropertyConfiguration<PersonName>
{
    public ComplexPropertyBuilder<PersonName> Configure(ComplexPropertyBuilder<PersonName> builder)
    {
        builder.Property(x => x.FirstSingleName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(50);

        builder.Property(x => x.LastSingleName)
            .HasMaxLength(50)
            .IsRequired();

        return builder;
    }
}