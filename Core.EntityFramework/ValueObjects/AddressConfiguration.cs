using Core.EntityFramework.Common;
using Core.ValueObjects.Complex;
using Core.ValueObjects.Simple;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework.ValueObjects;

public sealed class AddressConfiguration : IComplexPropertyConfiguration<Address>
{
	public ComplexPropertyBuilder<Address> Configure(ComplexPropertyBuilder<Address> builder)
	{
		builder.Property(x => x.Street)
			.HasColumnName("Street")
			.HasConversion<StringValueObjectConverter<Street>>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.City)
			.HasColumnName("City")
			.HasConversion<StringValueObjectConverter<City>>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.State)
			.HasColumnName("State")
			.HasConversion<StringValueObjectConverter<State>>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.ZipCode)
			.HasColumnName("ZipCode")
			.HasConversion<StringValueObjectConverter<ZipCode>>()
			.HasMaxLength(10)
			.IsRequired();

		return builder;
	}
}