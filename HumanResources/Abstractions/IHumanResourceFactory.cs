using Core.ComplexObjects;
using HumanResources.Entities;

namespace HumanResources.Abstractions;

public interface IHumanResourceFactory
{
	Employee CreateEmployee(EmployeePrimitiveValues primitiveValues);
	Person CreatePerson(EmployeePrimitiveValues primitiveValues);
}

public readonly record struct EmployeePrimitiveValues
{
	public string Title { get; init; }
	public string Type { get; init; }
	public string FirstName { get; init; }
	public string LastName { get; init; }
	public string Street { get; init; }
	public string City { get; init; }
	public string State { get; init; }
	public string ZipCode { get; init; }
	public string PhoneNumber { get; init; }
	public string Email { get; init; }
	public string PersonalIdentificationNumber { get; init; }
	public string ContractType { get; init; }
	public DateTime BirthDate { get; init; }
	public DateTime ContractStartDate { get; init; }
	public DateTime ContractEndDate { get; init; }
}