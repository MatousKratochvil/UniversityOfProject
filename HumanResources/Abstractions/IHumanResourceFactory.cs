﻿namespace HumanResources.Abstractions;

public interface IHumanResourceFactory
{
    Employee CreateEmployee(EmployeePrimitiveValues primitiveValues);
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
}