namespace Core;

public record PersonNameType(string FirstName, string? MiddleName, string LastName);

public static class PersonName
{
    public static PersonNameType Create(string firstName, string? middleName, string lastName)
    {
        Guard.ThrowWhenSmallerLength(firstName, 2);
        Guard.ThrowWhenSmallerLengthIgnoreNull(middleName, 1);
        Guard.ThrowWhenSmallerLength(lastName, 2);
        
        return new PersonNameType(firstName, middleName, lastName);
    }
}