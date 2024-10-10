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
        var cityNotNull = new ZipCode(name, Validation.NotNullValidator);
        var cityMinLength = new ZipCode(name, Validation.MinLengthThreeValidator);

        Assert.Equal(name, cityNotNull);
        Assert.Equal(name, cityMinLength);
    }
    
    [Theory]
    [InlineData("12345AaZz")]
    [InlineData("54321AaZz")]
    [InlineData("12345ěščřžýáíéúůů")]
    [InlineData("54321ěščřžýáíéúůů")]
    public void Create_WithInvalidArguments_LetterCheckCz_ThrowsArgumentException(string name)
    {
        ZipCodeValidator czValidator = (input, propertyName) => Validation.RegexValidator(CoreRegex.CheckForZipCode(), input, propertyName);
        Assert.Throws<ArgumentException>(() => new ZipCode(name, czValidator));
    }
}