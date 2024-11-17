using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct BirthDate : IDateValueObject
{
	public DateOnly Value { get; }

	private BirthDate(DateOnly value)
	{
		Value = value;
	}

	public static BirthDate Create(DateOnly value, BirthDateValidator? validator = null)
	{
		if (validator is not null)
			validator(value);
		else
			BasicValidator(value, nameof(BirthDate));

		return new BirthDate(value);
	}
	
	internal static BirthDate Create(DateOnly value) => new(value);
	
	private static BirthDateValidator BasicValidator => Guard.BasicDateValidator;

	public static implicit operator DateOnly(BirthDate birthDate) => birthDate.Value;

	public static implicit operator BirthDate(DateOnly birthDate) => new(birthDate);
}

public delegate void BirthDateValidator(DateOnly value, string? propertyName = null);