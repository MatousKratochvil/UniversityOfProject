using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct NationalIdentificationNumber : IStringValueObject
{
	public string Value { get; }

	private NationalIdentificationNumber(string value)
	{
		Value = value;
	}

	public static NationalIdentificationNumber Create(string value,
		NationalIdentificationNumberValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(NationalIdentificationNumber));

		return new NationalIdentificationNumber(value);
	}

	internal static NationalIdentificationNumber Create(string value) => new(value);

	private static NationalIdentificationNumberValidator BasicValidator => Guard.BasicStringValidator;

	public static implicit operator string(NationalIdentificationNumber value) => value.Value;
}

public delegate void NationalIdentificationNumberValidator(string value, string? propertyName = null);