using System.Runtime.CompilerServices;
using Core.Abstractions;

namespace Core.ValueObjects;

public record struct State : IStringValueObject
{
	public string Value { get; }

	public State(string value, StateValidator validator,
		[CallerArgumentExpression("value")] string? name = null)
	{
		validator(value, name);
		Value = value;
	}

	public State(string value)
	{
		Guard.ThrowWhenNullOrWhiteSpace(value);
		Value = value;
	}

	public static implicit operator string(State name) => name.Value;
}

public delegate void StateValidator(string value, string? propertyName = null);