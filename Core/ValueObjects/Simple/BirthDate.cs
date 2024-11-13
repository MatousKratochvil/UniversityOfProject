using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct BirthDate : IDateValueObject
{
	public DateTime Value { get; }

	private BirthDate(DateTime value)
	{
		Value = value;
	}

	public static BirthDate Create(DateTime value, BirthDateValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(BirthDate));

		return new BirthDate(value);
	}
	
	private static BirthDateValidator BasicValidator => Guard.BasicDateValidator;

	public static implicit operator DateTime(BirthDate birthDate) => birthDate.Value;

	public static implicit operator BirthDate(DateTime birthDate) => new(birthDate);
}

public delegate void BirthDateValidator(DateTime value, string? propertyName = null);