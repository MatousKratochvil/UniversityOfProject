using Core;
using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class StreetTests
{
    [Theory]
    [InlineData("123 Main St")]
    [InlineData("Springfield")]
    [InlineData("Elm")]
    [InlineData("Maple")]
    public void Create_WithValidArguments_ReturnsStreetType(string name)
    {
        var cityNotNull = new Street(name, NotNullValidator());
        var cityMinLength = new Street(name, MinLengthValidator(3));

        Assert.Equal(name, cityNotNull);
        Assert.Equal(name, cityMinLength);
    }

    [Theory]
    [InlineData("123 Main St", 12)]
    [InlineData("Springfield", 12)]
    [InlineData("Elm", 4)]
    [InlineData("Maple", 6)]
    public void Create_WithInvalidArguments_MinLength_ThrowsArgumentException(string name, int min)
    {
        Assert.Throws<ArgumentException>(() => new Street(name, MinLengthValidator(min)));
    }

    private static StreetValidator NotNullValidator() => (input, _)
        => Guard.ThrowWhenNullOrWhiteSpace(input);

    private static StreetValidator MinLengthValidator(int min) => (input, _)
        => Guard.ThrowWhenSmallerLength(input, min);
}