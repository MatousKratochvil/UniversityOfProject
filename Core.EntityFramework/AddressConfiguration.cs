using Core.ComplexObjects;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class AddressConfiguration : IComplexPropertyConfiguration<Address>
{
	public ComplexPropertyBuilder<Address> Configure(ComplexPropertyBuilder<Address> builder)
	{
		builder.Property(x => x.Street)
			.HasConversion<StreetConverter>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.City)
			.HasConversion<CityConverter>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.State)
			.HasConversion<StateConverter>()
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.ZipCode)
			.HasConversion<ZipCodeConverter>()
			.HasMaxLength(10)
			.IsRequired();

		return builder;
	}
}