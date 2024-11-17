using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct FirstName : IStringValueObject
{
	public string Value { get; }

	private FirstName(string value)
	{
		Value = value;
	}

	public static FirstName Create(string value, FirstNameValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(FirstName));

		return new FirstName(value);
	}
	
	internal static FirstName Create(string value) => new(value);

	private static FirstNameValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(FirstName value) => value.Value;
}

public delegate void FirstNameValidator(string value, string? propertyName = null);