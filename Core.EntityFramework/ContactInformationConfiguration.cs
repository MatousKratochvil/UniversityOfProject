using Core.ComplexObjects;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class ContactInformationConfiguration : IComplexPropertyConfiguration<ContactInformation>
{
	public ComplexPropertyBuilder<ContactInformation> Configure(ComplexPropertyBuilder<ContactInformation> builder)
	{
		builder.ComplexProperty(x => x.Address).Configure(new AddressConfiguration());

		builder.Property(x => x.Email)
			.HasConversion<EmailConverter>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.PhoneNumber)
			.HasConversion<PhoneNumberConverter>()
			.HasMaxLength(50)
			.IsRequired();

		return builder;
	}
}