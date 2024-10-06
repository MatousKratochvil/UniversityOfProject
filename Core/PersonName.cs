namespace Core;

public record PersonName
{
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }

    private PersonName(string firstName, string? middleName, string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    public static PersonName Create(string firstName, string? middleName, string lastName)
    {
        Guard.ThrowWhenOutOfLengthRange(firstName, 2, 50);
        Guard.ThrowWhenOutOfLengthRangeIgnoreNull(middleName, 1, 50);
        Guard.ThrowWhenOutOfLengthRange(lastName, 2, 50);

        return new PersonName(firstName, middleName, lastName);
    }
}
