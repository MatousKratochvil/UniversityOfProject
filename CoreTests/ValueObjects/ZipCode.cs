using Core;
using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class ZipCodeTests
{
    [Theory]
    [InlineData("12345")]
    [InlineData("54321")]
    [InlineData("543 21")]
    [InlineData("543-21")]
    [InlineData("543  21")]
    public void Create_WithValidArguments_ReturnsCityType(string name)
    {
        var cityNotNull = new ZipCode(name, NotNullValidator(), CoreRegex.CheckForLetters());
        var cityMinLength = new ZipCode(name, MinLengthValidator(3), CoreRegex.CheckForLetters());

        Assert.Equal(name, cityNotNull);
        Assert.Equal(name, cityMinLength);
    }
    
    [Theory]
    [InlineData("12345AaZz")]
    [InlineData("54321AaZz")]
    public void Create_WithInvalidArguments_LetterCheck_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new ZipCode(name, NotNullValidator(), CoreRegex.CheckForLetters()));
    }
    
    [Theory]
    [InlineData("12345ěščřžýáíéúůů")]
    [InlineData("54321ěščřžýáíéúůů")]
    public void Create_WithInvalidArguments_LetterCheckCz_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new ZipCode(name, NotNullValidator(), CoreRegex.CheckForLettersInCz()));
    }

    private static ZipCodeValidator MinLengthValidator(int i) => (input, _)
        => Guard.ThrowWhenSmallerLength(input, i);

    private static ZipCodeValidator NotNullValidator() => (input, _)
        => Guard.ThrowWhenNullOrWhiteSpace(input);
}