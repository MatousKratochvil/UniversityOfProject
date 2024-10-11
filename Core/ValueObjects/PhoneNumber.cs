using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct PhoneNumber : IStringValueObject
{
	public string Value { get; }

	public PhoneNumber(string value, PhoneNumberValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Value = value;
	}

	public PhoneNumber(string value)
	{
		Guard.ThrowWhenNullOrWhiteSpace(value);
		Guard.ThrowWhenRegexNotMatch(value, CoreRegex.CheckForPhoneNumber());
		Value = value;
	}

	public static implicit operator string(PhoneNumber name) => name.Value;
}

public delegate void PhoneNumberValidator(string value, string? propertyName = null);