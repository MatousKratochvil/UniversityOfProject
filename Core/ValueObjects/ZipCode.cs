using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct ZipCode : IStringValueObject
{
	public string Value { get; }

	public ZipCode(string value, ZipCodeValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Value = value;
	}

	public ZipCode(string value)
	{
		Guard.ThrowWhenNullOrWhiteSpace(value);
		Guard.ThrowWhenRegexNotMatch(value, CoreRegex.CheckForZipCode());
		Value = value;
	}

	public static implicit operator string(ZipCode name) => name.Value;
}

public delegate void ZipCodeValidator(string value, string? propertyName = null);