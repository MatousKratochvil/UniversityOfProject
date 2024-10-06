using Core;

namespace CoreTests;


public class PersonNameTypeTest
{
    [Theory]
    [InlineData("John", null, "Doe")]
    [InlineData("John", "M", "Doe")]
    [InlineData("John", "Middle", "Doe")]
    public void Create_WithValidArguments_ReturnsPersonNameType(string firstName, string? middleName, string lastName)
    {
        var personName = PersonName.Create(firstName, middleName, lastName);

        Assert.Equal(firstName, personName.FirstName);
        Assert.Equal(middleName, personName.MiddleName);
        Assert.Equal(lastName, personName.LastName);
    }
    
    [Theory]
    [InlineData("J", null, "Doe")]
    [InlineData("J", "M", "Doe")]
    [InlineData("J", "M", "D")]
    [InlineData("John", "M", "D")]
    [InlineData("John", "", "Doe")]
    public void Create_WithInvalidArguments_ThrowsArgumentException(string firstName, string? middleName, string lastName)
    {
        Assert.Throws<ArgumentException>(() => PersonName.Create(firstName, middleName, lastName));
    }
}