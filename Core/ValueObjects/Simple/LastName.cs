using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct LastName : IStringValueObject
{
	public string Value { get; }

	private LastName(string value)
	{
		Value = value;
	}

	public static LastName Create(string value, LastNameValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(LastName));

		return new LastName(value);
	}
	
	internal static LastName Create(string value) => new(value);

	private static LastNameValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(LastName value) => value.Value;
}

public delegate void LastNameValidator(string value, string? propertyName = null);