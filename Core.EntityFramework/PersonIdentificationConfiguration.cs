using Core.ComplexObjects;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class PersonIdentificationConfiguration : IComplexPropertyConfiguration<PersonIdentification>
{
	public ComplexPropertyBuilder<PersonIdentification> Configure(ComplexPropertyBuilder<PersonIdentification> builder)
	{
		builder.Property(x => x.BirthDate)
			.HasConversion<BirthDateConverter>()
			.HasMaxLength(10)
			.IsRequired();

		builder.Property(x => x.PersonalIdentificationNumber)
			.HasConversion<PersonalIdentificationNumberConverter>()
			.HasMaxLength(20)
			.IsRequired();

		return builder;
	}
}