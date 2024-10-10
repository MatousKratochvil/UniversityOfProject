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
        var cityNotNull = new Street(name, Validation.NotNullValidator);
        var cityMinLength = new Street(name, Validation.MinLengthThreeValidator);

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
        StreetValidator validator = (input, propertyName) => Validation.MinLengthValidator(input, min, propertyName);
        Assert.Throws<ArgumentException>(() => new Street(name, validator));
    }
}