using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct Email : IStringValueObject
{
	public string Value { get; }

	public Email(string value, EmailValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Value = value;
	}

	public Email(string value)
	{
		Guard.ThrowWhenNullOrWhiteSpace(value);
		Guard.ThrowWhenRegexNotMatch(value, CoreRegex.CheckForEmail());
		Value = value;
	}

	public static implicit operator string(Email name) => name.Value;
}

public delegate void EmailValidator(string value, string? propertyName = null);