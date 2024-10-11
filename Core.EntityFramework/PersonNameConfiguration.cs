using System.ComponentModel;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class PersonNameConfiguration : IComplexPropertyConfiguration<PersonName>
{
    public ComplexPropertyBuilder<PersonName> Configure(ComplexPropertyBuilder<PersonName> builder)
    {
        builder.Property(x => x.FirstSingleName)
            .HasConversion<SingleNameConverter>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasConversion<SingleNameConverter>()
            .HasMaxLength(50);

        builder.Property(x => x.LastSingleName)
            .HasConversion<SingleNameConverter>()
            .HasMaxLength(50)
            .IsRequired();

        return builder;
    }
}