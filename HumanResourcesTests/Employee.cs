using Core.ComplexObjects;
using Core.ValueObjects;
using HumanResources.Entities;

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
        var personIdentification = new PersonIdentification(
            new BirthDate(new DateTime(2000, 1, 1)),
            new PersonalIdentificationNumber("123456789"));
        var contactInformation = new ContactInformation(
            new Email("test@test.cz"),
            new PhoneNumber("123 456 789"));

        var person = new Person(title, name, personIdentification, address, contactInformation);
        // Act
        var employee = new RegularEmployee(id, person, null);

        // Assert
        Assert.Equal(id, employee.Id);
        Assert.Equal(person, employee.Person);
        
    }
}