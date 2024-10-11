using System.Globalization;

namespace Core.ValueObjects;

public record struct InvalidPastDate(DateTime Value) : IPastDate
{
	public DateTime Value { get; } = Value;

	public static implicit operator string(InvalidPastDate name) => name.Value.ToString(CultureInfo.CurrentCulture);
}

public record struct InvalidFutureDate(DateTime Value) : IFutureDate
{
	public DateTime Value { get; } = Value;

	public static implicit operator string(InvalidFutureDate name) => name.Value.ToString(CultureInfo.CurrentCulture);
}