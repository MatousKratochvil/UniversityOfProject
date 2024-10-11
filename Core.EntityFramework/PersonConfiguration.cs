using Core.ComplexObjects;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class PersonConfiguration : IComplexPropertyConfiguration<Person>
{
    public ComplexPropertyBuilder<Person> Configure(ComplexPropertyBuilder<Person> builder)
    {
        builder.ComplexProperty(x => x.Address).Configure(new AddressConfiguration());
        builder.ComplexProperty(x => x.Name).Configure(new PersonNameConfiguration());
        builder.ComplexProperty(x => x.ContactInformation).Configure(new ContactInformationConfiguration());
        builder.ComplexProperty(x => x.Identification).Configure(new PersonIdentificationConfiguration());

        builder.Property(x => x.Title)
            .HasConversion<TitleConverter>()
            .HasMaxLength(100);

        return builder;
    }
}