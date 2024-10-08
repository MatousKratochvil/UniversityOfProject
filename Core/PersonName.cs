using Core.ValueObjects;

namespace Core;

/// <summary>
/// Value object to represent a person's name.
/// </summary>
public record PersonName
{
    public Name FirstName { get; }
    public Name? MiddleName { get; }
    public Name LastName { get; }

    private PersonName(Name firstName, Name? middleName, Name lastName)
    {
        FirstName = firstName;
        if (middleName != null) MiddleName = middleName;
        LastName = lastName;
    }

    public static PersonName Create(string firstName, string? middleName, string lastName)
        => new(
            new Name(firstName, ValidateName),
            middleName is not null ? new Name(middleName, ValidateMiddleName) : null,
            new Name(lastName, ValidateName)
        );

    private static void ValidateName(string value, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(value, 2, 50, propertyName);

    private static void ValidateMiddleName(string value, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(value, 1, 50, propertyName);
}