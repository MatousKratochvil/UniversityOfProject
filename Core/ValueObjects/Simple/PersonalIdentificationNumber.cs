using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct PersonalIdentificationNumber : IStringValueObject
{
	public string Value { get; }

	private PersonalIdentificationNumber(string value)
	{
		Value = value;
	}

	public static PersonalIdentificationNumber Create(string value,
		PersonalIdentificationNumberValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(PersonalIdentificationNumber));

		return new PersonalIdentificationNumber(value);
	}

	private static PersonalIdentificationNumberValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(PersonalIdentificationNumber value) => value.Value;
}

public delegate void PersonalIdentificationNumberValidator(string value, string? propertyName = null);