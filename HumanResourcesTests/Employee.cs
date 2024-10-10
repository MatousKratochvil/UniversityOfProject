using Core.ValueObjects;
using HumanResources;

namespace HumanResourcesTests;

public class EmployeeTests
{
    [Fact]
    public void Employee_WithValidTitleAndName_ShouldCreateEmployee()
    {
        // Arrange
        var title = new Title("Mr.", BasicValidator);
        var name = new PersonName(new SingleName("John", BasicValidator), null, new SingleName("Doe", BasicValidator));
        var address = new Address(new Street("1234 Main St", BasicValidator), new City("Anytown", BasicValidator),
            new State("ST", BasicValidator), new ZipCode("12345", BasicValidator));
        var contactInformation = new ContactInformation(new Email("test@test.cz", BasicValidator),
            new PhoneNumber("123 456 789", BasicValidator));

        // Act
        var employee = new Employee(title, name, address, contactInformation);

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