using Core.ComplexObjects;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using Core.Representations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public sealed class PeriodRepresentationConfiguration : IComplexPropertyConfiguration<PeriodRepresentation>
{
	public ComplexPropertyBuilder<PeriodRepresentation> Configure(ComplexPropertyBuilder<PeriodRepresentation> builder)
	{
		builder.Property(x => x.Discriminator)
			.HasConversion(new TypeConverter(typeof(ValidPeriod), typeof(InvalidPeriod)));

		builder.Property(x => x.Start)
			.HasConversion<PastDateConverter>()
			.IsRequired();

		builder.Property(x => x.End)
			.HasConversion<FutureDateConverter>()
			.IsRequired();

		return builder;
	}
}