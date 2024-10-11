﻿using Core.Abstractions;
using HumanResources.Abstractions;
using HumanResources.Entities;
using MediatR;

namespace HumanResources.Commands;

public sealed record CreateEmployeeRequest(EmployeePrimitiveValues PrimitiveValues) : IRequest<CreateEmployeeResponse>;

public sealed record CreateEmployeeResponse(EmployeeId Id);

internal sealed class CreateEmployeeRequestHandler(
    IHumanResourcesDbContext context,
    IHumanResourceFactory factory,
    IUserContext userContext)
    : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
{
    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = factory.CreateEmployee(request.PrimitiveValues);

        context.Employees.Add(employee);
        await context.SaveChangesAsync(cancellationToken);

        return new CreateEmployeeResponse(employee.Id);
    }
}