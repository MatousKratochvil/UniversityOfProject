using Core.Abstractions;
using Core.ValueObjects;
using HumanResources.Abstractions;
using MediatR;

namespace HumanResources.Commands;

public sealed record CreateEmployeeRequest : IRequest<CreateEmployeeResponse>
{
    public required EmployeePrimitiveValues PrimitiveValues { get; init; }
}

public sealed record CreateEmployeeResponse
{
    public Guid Id { get; set; }
}

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

        return new CreateEmployeeResponse { Id = employee.Id };
    }
}