using Core;
using Core.CompositeValueObjects;
using Core.ValueObjects;
using HumanResources;

namespace HumanResourcesTests;

public class EmployeeTests
{
    [Fact]
    public void Employee_WithValidTitleAndName_ShouldCreateEmployee()
    {
        // Arrange
        var title = new PersonTitle("Mr.", BasicValidator);
        var name = new PersonName(new SingleName("John", BasicValidator), new SingleName("Doe", BasicValidator));
        var address = new Address(new Street("1234 Main St", BasicValidator), new City("Anytown", BasicValidator),
            new AddressState("ST", BasicValidator), new ZipCode("12345", BasicValidator, CoreRegex.CheckForLetters()));

        // Act
        var employee = new Employee(title, name, address);

        // Assert
        Assert.Equal(title, employee.Title);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
    }

    private void BasicValidator(string value, string? propertyname)
    {
        // Do nothing
    }
}