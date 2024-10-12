using Core.ComplexObjects;
using Core.ValueObjects;
using HumanResources.Abstractions;
using HumanResources.Entities;

namespace HumanResources;

internal class HumanResourceFactory : IHumanResourceFactory
{
	public Employee CreateEmployee(EmployeePrimitiveValues primitiveValues)
	{
		var employee = InnerCreateEmployee(primitiveValues);
		var department = CreateDepartment();
		var contract = CreateContract(primitiveValues, employee, department);

		employee.Contract = contract;
		return employee;
	}

	private Employee InnerCreateEmployee(EmployeePrimitiveValues primitiveValues) =>
		primitiveValues.Type switch
		{
			"Professor" => new Professor(EmployeeId.Empty, CreatePerson(primitiveValues), null),
			"Administrative" => new AdministrativeEmployee(EmployeeId.Empty, CreatePerson(primitiveValues), null),
			"Regular" => new RegularEmployee(EmployeeId.Empty, CreatePerson(primitiveValues), null),
			_ => throw new ArgumentOutOfRangeException(nameof(primitiveValues.Type))
		};

	private EmploymentContract CreateContract(EmployeePrimitiveValues primitiveValues,
		Employee employee,
		Department department)
	{
		var period = new ValidPeriod(new PastDate(primitiveValues.ContractStartDate),
			new FutureDate(primitiveValues.ContractEndDate));
		return primitiveValues.ContractType switch
		{
			"Permanent" => new PermanentContract(EmploymentContractId.Empty, period, employee, department),
			"Temporary" => new TemporaryContract(EmploymentContractId.Empty, period, employee, department),
			_ => throw new ArgumentOutOfRangeException(nameof(primitiveValues.ContractType))
		};
	}

	private EmploymentContract CreateContract(EmployeePrimitiveValues primitiveValues)
	{
		var period = new ValidPeriod(new PastDate(primitiveValues.ContractStartDate),
			new FutureDate(primitiveValues.ContractEndDate));
		return primitiveValues.ContractType switch
		{
			"Permanent" => new PermanentContract(EmploymentContractId.Empty, period, null, null),
			"Temporary" => new TemporaryContract(EmploymentContractId.Empty, period, null, null),
			_ => throw new ArgumentOutOfRangeException(nameof(primitiveValues.ContractType))
		};
	}

	private Department CreateDepartment() =>
		new()
		{
			Id = DepartmentId.Empty,
			Name = new SingleName("HumanResources"),
		};

	public Person CreatePerson(EmployeePrimitiveValues primitiveValues) =>
		new(
			new Title(primitiveValues.Title),
			new PersonName(new SingleName(primitiveValues.FirstName), null, new SingleName(primitiveValues.LastName)),
			new PersonIdentification(new BirthDate(primitiveValues.BirthDate),
				new PersonalIdentificationNumber(primitiveValues.PersonalIdentificationNumber)),
			new Address(new Street(primitiveValues.Street), new City(primitiveValues.City),
				new State(primitiveValues.State), new ZipCode(primitiveValues.ZipCode)),
			new ContactInformation(new Email(primitiveValues.Email), new PhoneNumber(primitiveValues.PhoneNumber)));
}