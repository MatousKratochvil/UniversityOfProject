using Core.ValueObjects;

namespace Core.CompositeValueObjects;

/// <summary>
/// Value object to represent a person's name.
/// </summary>
public sealed record PersonName
{
    public SingleName FirstSingleName { get; }
    public SingleName? MiddleName { get; }
    public SingleName LastSingleName { get; }

    public PersonName(SingleName firstSingleName, SingleName lastSingleName)
    {
        FirstSingleName = firstSingleName;
        LastSingleName = lastSingleName;
    }
    
    public PersonName(SingleName firstSingleName, SingleName? middleName, SingleName lastSingleName)
    {
        FirstSingleName = firstSingleName;
        if (middleName != null) MiddleName = middleName;
        LastSingleName = lastSingleName;
    }

    public static PersonName CreateBasic(string firstName, string? middleName, string lastName)
        => new(
            new SingleName(firstName, ValidateName),
            middleName is not null
                ? new SingleName(middleName, ValidateMiddleName)
                : null,
            new SingleName(lastName, ValidateName)
        );

    private static void ValidateName(string value, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(value, 2, 50, propertyName);

    private static void ValidateMiddleName(string value, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(value, 1, 50, propertyName);
}