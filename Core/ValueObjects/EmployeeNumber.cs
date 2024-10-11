using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct EmployeeNumber : IStringValueObject
{
	public string Value { get; }

	public EmployeeNumber(string value, EmployeeNumberValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Value = value;
	}

	public EmployeeNumber(string value)
	{
		Guard.ThrowWhenNullOrWhiteSpace(value);
		Value = value;
	}

	public static implicit operator string(EmployeeNumber name) => name.Value;
}

public delegate void EmployeeNumberValidator(string value, string? propertyName = null);