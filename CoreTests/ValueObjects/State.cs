using Core;
using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class StateTests
{
    [Theory]
    [InlineData("New York")]
    [InlineData("California")]
    public void Create_WithValidArguments_ReturnsStateType(string name)
    {
        var cityNotNull = new AddressState(name, NotNullValidator());
        var cityMinLength = new AddressState(name, MinLengthValidator(3));

        Assert.Equal(name, cityNotNull);
        Assert.Equal(name, cityMinLength);
    }

    [Theory]
    [InlineData("New York", 9)]
    [InlineData("California", 12)]
    public void Create_WithInvalidArguments_MinLength_ThrowsArgumentException(string name, int min)
    {
        Assert.Throws<ArgumentException>(() => new AddressState(name, MinLengthValidator(min)));
    }

    private static StateValidator NotNullValidator() => (input, _)
        => Guard.ThrowWhenNullOrWhiteSpace(input);

    private static StateValidator MinLengthValidator(int min) => (input, _)
        => Guard.ThrowWhenSmallerLength(input, min);
}