using Core.ComplexObjects;
using Core.ValueObjects;

namespace Core.Representations;

public record PeriodRepresentation(Type Discriminator, IPastDate Start, IFutureDate End);

public static class PeriodRepresentationConversion
{
	public static Period ToPeriod(this PeriodRepresentation representation)
	{
		return representation.Discriminator.Name switch
		{
			"ValidPeriod" => new ValidPeriod(representation.Start, representation.End),
			"InvalidPeriod" => new InvalidPeriod(representation.Start, representation.End),
			_ => throw new InvalidOperationException()
		};
	}

	public static PeriodRepresentation ToRepresentation(this Period period)
	{
		return period switch
		{
			ValidPeriod validPeriod => new PeriodRepresentation(typeof(ValidPeriod), validPeriod.Start, validPeriod.End),
			InvalidPeriod invalidPeriod => new PeriodRepresentation(typeof(InvalidPeriod), invalidPeriod.Start, invalidPeriod.End),
			_ => throw new InvalidOperationException()
		};
	}

}