using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct State : IStringValueObject
{
	public string Value { get; }

	private State(string value)
	{
		Value = value;
	}

	public static State Create(string value, StateValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(State));

		return new State(value);
	}
	
	internal static State Create(string value) => new(value);

	private static StateValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(State value) => value.Value;
}

public delegate void StateValidator(string value, string? propertyName = null);