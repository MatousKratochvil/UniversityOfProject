using Core.ValueObjects;

namespace CoreTests.ValueObjects;

public class SingleNameTests
{
    [Theory]
    [InlineData("John")]
    [InlineData("Doe")]
    public void Create_WithValidArguments_ReturnsSingleNameType(string name)
    {
        var nameNotNull = new SingleName(name, Validation.NotNullValidator);
        var nameMinLength = new SingleName(name, Validation.MinLengthThreeValidator);

        Assert.Equal(name, nameNotNull);
        Assert.Equal(name, nameMinLength);
    }

    [Theory]
    [InlineData("John Doe")]
    [InlineData("John Doe Smith")]
    [InlineData("John Doe Smith Jr.")]
    public void Create_WithInvalidArguments_SpaceInside_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new SingleName(name, Validation.EmptyValidation));
    }


    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithInvalidArguments_NotNull_ThrowsArgumentException(string name)
    {
        Assert.Throws<ArgumentException>(() => new SingleName(name, Validation.NotNullValidator));
    }

    [Theory]
    [InlineData("John", 9)]
    [InlineData("Doe", 12)]
    public void Create_WithInvalidArguments_MinLength_ThrowsArgumentException(string name, int min)
    {
        SingleNameValidator validator = (input, propertyName) => Validation.MinLengthValidator(input, min, propertyName);
        Assert.Throws<ArgumentException>(() => new SingleName(name, validator));
    }
}