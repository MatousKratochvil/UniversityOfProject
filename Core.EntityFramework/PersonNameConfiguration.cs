using Core.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public class PersonNameConfiguration : IComplexPropertyConfiguration<PersonName>
{
    public ComplexPropertyBuilder<PersonName> Configure(ComplexPropertyBuilder<PersonName> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();

        return builder;
    }
}