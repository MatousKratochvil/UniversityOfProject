using Core.Abstractions;
using HumanResources.Abstractions;
using HumanResources.Entities;
using HumanResources.Events;
using MediatR;

namespace HumanResources.Commands;

public sealed record EmployeeCreateRequest(EmployeePrimitiveValues PrimitiveValues) : IRequest<EmployeeCreateResponse>;

public sealed record EmployeeCreateResponse(EmployeeId Id);

internal sealed class EmployeeCreateRequestHandler(
	IPublisher publisher,
	IHumanResourcesDbContext context,
	IHumanResourceFactory factory,
	IUserContext userContext)
	: IRequestHandler<EmployeeCreateRequest, EmployeeCreateResponse>
{
	public async Task<EmployeeCreateResponse> Handle(EmployeeCreateRequest request, CancellationToken cancellationToken)
	{
		var employee = factory.CreateEmployee(request.PrimitiveValues);

		context.AddEntity(employee);
		await context.SaveChangesAsync(cancellationToken);

		await publisher.Publish(new EmployeeCreated(employee, userContext.User), cancellationToken);
		return new EmployeeCreateResponse(employee.Id);
	}
}