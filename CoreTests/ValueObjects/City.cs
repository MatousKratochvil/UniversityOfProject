using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class CityTests
{
    [Theory]
    [InlineData("New York")]
    [InlineData("Los Angeles")]
    public void Create_WithValidArguments_ReturnsCityType(string name)
    {
        var cityNotNull = new City(name, Validation.NotNullValidator);
        var cityMinLength = new City(name, Validation.NotNullValidator);

        Assert.Equal(name, cityNotNull);
        Assert.Equal(name, cityMinLength);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithInvalidArguments_NotNull_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new City(name, Validation.NotNullValidator));
    }

    [Theory]
    [InlineData("New York", 9)]
    [InlineData("Los Angeles", 12)]
    public void Create_WithInvalidArguments_MinLength_ThrowsArgumentException(string name, int min)
    {
        CityValidator validator = (input, propertyName) => Validation.MinLengthValidator(input, min, propertyName);
        Assert.Throws<ArgumentException>(() => new City(name, validator));
    }
}