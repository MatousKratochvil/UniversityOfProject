using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class StateTests
{
    [Theory]
    [InlineData("New York")]
    [InlineData("California")]
    public void Create_WithValidArguments_ReturnsStateType(string name)
    {
        var cityNotNull = new State(name, Validation.NotNullValidator);
        var cityMinLength = new State(name, Validation.MinLengthThreeValidator);

        Assert.Equal(name, cityNotNull);
        Assert.Equal(name, cityMinLength);
    }

    [Theory]
    [InlineData("New York", 9)]
    [InlineData("California", 12)]
    public void Create_WithInvalidArguments_MinLength_ThrowsArgumentException(string name, int min)
    {
        StateValidator validator = (input, propertyName) => Validation.MinLengthValidator(input, min, propertyName);
        Assert.Throws<ArgumentException>(() => new State(name, validator));
    }
}