using Core.ValueObjects;

namespace Core;

/// <summary>
/// Value object to represent a person's name.
/// </summary>
public record PersonName
{
    public SingleName FirstSingleName { get; }
    public SingleName? MiddleName { get; }
    public SingleName LastSingleName { get; }

    private PersonName(SingleName firstSingleName, SingleName? middleName, SingleName lastSingleName)
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
    
    public static PersonName Create(SingleName firstSingleName, SingleName? middleName, SingleName lastSingleName)
        => new(firstSingleName, middleName, lastSingleName);

    private static void ValidateName(string value, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(value, 2, 50, propertyName);

    private static void ValidateMiddleName(string value, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(value, 1, 50, propertyName);
}