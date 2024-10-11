using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct Title : IStringValueObject
{
	public string Value { get; }

	public Title(string value, TitleValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Value = value;
	}

	public Title(string value)
	{
		Guard.ThrowWhenNullOrWhiteSpace(value);
		Value = value;
	}

	public static implicit operator string(Title name) => name.Value;
}

public delegate void TitleValidator(string value, string? propertyName = null);