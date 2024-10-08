using Core;
using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class CityTests
{
    [Theory]
    [InlineData("New York")]
    [InlineData("Los Angeles")]
    public void Create_WithValidArguments_ReturnsCityType(string name)
    {
        var cityNotNull = new City(name, NotNullValidator());
        var cityMinLength = new City(name, MinLengthValidator(3));

        Assert.Equal(name, cityNotNull);
        Assert.Equal(name, cityMinLength);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithInvalidArguments_NotNull_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new City(name, NotNullValidator()));
    }

    [Theory]
    [InlineData("New York", 9)]
    [InlineData("Los Angeles", 12)]
    public void Create_WithInvalidArguments_MinLength_ThrowsArgumentException(string name, int min)
    {
        Assert.Throws<ArgumentException>(() => new City(name, MinLengthValidator(min)));
    }

    private static CityValidator NotNullValidator() => (input, _)
        => Guard.ThrowWhenNullOrWhiteSpace(input);

    private static CityValidator MinLengthValidator(int min) => (input, _)
        => Guard.ThrowWhenSmallerLength(input, min);
}