using System.Globalization;
using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct BirthDate : IDateValueObject
{
	public DateTime Value { get; }

	public BirthDate(DateTime value, BirthDateValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Value = value;
	}

	public BirthDate(DateTime value)
	{
		Guard.ThrowWhenDefault(value);
		Value = value;
	}

	public static implicit operator string(BirthDate name) => name.Value.ToString(CultureInfo.CurrentCulture);
}

public delegate void BirthDateValidator(DateTime value, string? propertyName = null);