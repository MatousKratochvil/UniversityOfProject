using Core;
using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class SingleNameTests
{
    [Theory]
    [InlineData("John")]
    [InlineData("Doe")]
    public void Create_WithValidArguments_ReturnsSingleNameType(string name)
    {
        var nameNotNull = new SingleName(name, NotNullValidator());
        var nameMinLength = new SingleName(name, MinLengthValidator(3));

        Assert.Equal(name, nameNotNull);
        Assert.Equal(name, nameMinLength);
    }

    [Theory]
    [InlineData("John Doe")]
    [InlineData("John Doe Smith")]
    [InlineData("John Doe Smith Jr.")]
    public void Create_WithInvalidArguments_SpaceInside_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new SingleName(name, NoValidator()));
    }


    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithInvalidArguments_NotNull_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new SingleName(name, NotNullValidator()));
    }

    [Theory]
    [InlineData("John", 9)]
    [InlineData("Doe", 12)]
    public void Create_WithInvalidArguments_MinLength_ThrowsArgumentException(string name, int min)
    {
        Assert.Throws<ArgumentException>(() => new SingleName(name, MinLengthValidator(min)));
    }

    private static SingleNameValidator NotNullValidator() => (input, _)
        => Guard.ThrowWhenNullOrWhiteSpace(input);

    private static SingleNameValidator MinLengthValidator(int min) => (input, _)
        => Guard.ThrowWhenSmallerLength(input, min);

    private static SingleNameValidator NoValidator() => (_, _)
        =>
    {
    };
}