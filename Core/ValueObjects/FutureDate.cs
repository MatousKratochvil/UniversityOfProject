using System.Globalization;
using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public interface IFutureDate : IDateValueObject;

public record struct FutureDate : IFutureDate
{
	public DateTime Value { get; }

	public FutureDate(DateTime value, FutureDateValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Guard.ThrowWhenSmallerThen(value, DateTime.Now);
		Value = value;
	}

	public FutureDate(DateTime value)
	{
		Guard.ThrowWhenSmallerThen(value, DateTime.Now);
		Value = value;
	}

	public static implicit operator string(FutureDate name) => name.Value.ToString(CultureInfo.CurrentCulture);
}

public delegate void FutureDateValidator(DateTime value, string? propertyName = null);