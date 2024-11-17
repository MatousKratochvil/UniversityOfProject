using Core.EntityFramework.Common;
using Core.ValueObjects.Complex;
using Core.ValueObjects.Simple;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework.ValueObjects;

public sealed class ContactInformationConfiguration : IComplexPropertyConfiguration<ContactInformation>
{
	public ComplexPropertyBuilder<ContactInformation> Configure(ComplexPropertyBuilder<ContactInformation> builder)
	{
		builder.Property(x => x.EmailAddress)
			.HasColumnName("EmailAddress")
			.HasConversion<StringValueObjectConverter<EmailAddress>>()
			.HasMaxLength(50)
			.IsRequired();
		
		builder.Property(x => x.PhoneNumber)
			.HasColumnName("PhoneNumber")
			.HasConversion<StringValueObjectConverter<PhoneNumber>>()
			.HasMaxLength(50)
			.IsRequired();

		builder.ComplexProperty(x => x.HomeAddress).Configure(new AddressConfiguration());

		return builder;
	}
}