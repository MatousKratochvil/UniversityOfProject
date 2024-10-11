using System.Globalization;
using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public interface IPastDate : IDateValueObject;

public record struct PastDate : IPastDate
{
	public DateTime Value { get; }

	public PastDate(DateTime value, PastDateValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Guard.ThrowWhenGreaterThen(value, DateTime.Now);
		Value = value;
	}

	public PastDate(DateTime value)
	{
		Guard.ThrowWhenGreaterThen(value, DateTime.Now);
		Value = value;
	}

	public static implicit operator string(PastDate name) => name.Value.ToString(CultureInfo.CurrentCulture);
}

public delegate void PastDateValidator(DateTime value, string? propertyName = null);