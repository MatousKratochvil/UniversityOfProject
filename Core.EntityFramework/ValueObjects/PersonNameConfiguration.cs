using Core.EntityFramework.Common;
using Core.ValueObjects.Complex;
using Core.ValueObjects.Simple;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework.ValueObjects;

public sealed class PersonNameConfiguration : IComplexPropertyConfiguration<PersonName>
{
	public ComplexPropertyBuilder<PersonName> Configure(ComplexPropertyBuilder<PersonName> builder)
	{
		builder.Property(x => x.FirstName)
			.HasColumnName("FirstName")
			.HasConversion<StringValueObjectConverter<FirstName>>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.MiddleName)
			.HasColumnName("MiddleName")
			.HasConversion<StringValueObjectConverter<MiddleName>>()
			.HasMaxLength(50);

		builder.Property(x => x.LastName)
			.HasColumnName("LastName")
			.HasConversion<StringValueObjectConverter<LastName>>()
			.HasMaxLength(50)
			.IsRequired();

		return builder;
	}
}