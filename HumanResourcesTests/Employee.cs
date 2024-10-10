using Core.ValueObjects;
using HumanResources;

namespace HumanResourcesTests;

public class EmployeeTests
{
    [Fact]
    public void Employee_WithValidTitleAndNameNoValidations_ShouldCreateEmployee()
    {
        // Arrange
        var id = new EmployeeId(Guid.NewGuid());
        var employeeNumber = new EmployeeNumber("123456");
        var title = new Title("Mr.");
        var name = new PersonName(
            new SingleName("John"),
            null,
            new SingleName("Doe"));
        var address = new Address(
            new Street("1234 Main St"),
            new City("Anytown"),
            new State("ST"),
            new ZipCode("12345"));
        var contactInformation = new ContactInformation(
            new Email("test@test.cz"),
            new PhoneNumber("123 456 789"));
        // Act
        var employee = new RegularEmployee(id, employeeNumber, title, name, address, contactInformation);

        // Assert
        Assert.Equal(id, employee.Id);
        Assert.Equal(employeeNumber, employee.EmployeeNumber);
        Assert.Equal(title, employee.Title);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(contactInformation, employee.ContactInformation);
    }
}