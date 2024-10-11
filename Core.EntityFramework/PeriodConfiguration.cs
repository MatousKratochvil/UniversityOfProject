using Core.ComplexObjects;
using Core.EntityFramework.Common;
using Core.EntityFramework.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework;

public class PeriodConfiguration : IComplexPropertyConfiguration<Period>
{
	public ComplexPropertyBuilder<Period> Configure(ComplexPropertyBuilder<Period> builder)
	{
		builder.Property(x => x.Start)
			.HasConversion<PastDateCoverter>()
			.IsRequired();
		
		builder.Property(x => x.End)
			.HasConversion<FutureDateConverter>()
			.IsRequired();

		return builder;
	}
}