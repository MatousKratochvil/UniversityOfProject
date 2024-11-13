using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct SingleName : IStringValueObject
{
	public string Value { get; }

	private SingleName(string value)
	{
		Value = value;
	}

	public static SingleName Create(string value, SingleNameValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(SingleName));

		return new SingleName(value);
	}

	private static SingleNameValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(SingleName value) => value.Value;
}

public delegate void SingleNameValidator(string value, string? propertyName = null);