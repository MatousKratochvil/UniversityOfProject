using Core.Abstractions;
using HumanResources.Abstractions;
using HumanResources.Entities;
using HumanResources.Events;
using MediatR;

namespace HumanResources.Commands;

public sealed record EmployeeCreateCommand(Employee Employee) : IRequest<EmployeeCreateCommandResponse>;

public sealed record EmployeeCreateCommandResponse(EmployeeId Id);

internal sealed class EmployeeCreateCommandHandler(
	IPublisher publisher,
	IHumanResourcesDbContext context,
	IHumanResourceFactory factory,
	IUserContext userContext)
	: IRequestHandler<EmployeeCreateCommand, EmployeeCreateCommandResponse>
{
	public async Task<EmployeeCreateCommandResponse> Handle(EmployeeCreateCommand command, CancellationToken cancellationToken)
	{
		context.AddEntity(command.Employee);
		await context.SaveChangesAsync(cancellationToken);

		await publisher.Publish(new EmployeeCreated(command.Employee, userContext.User), cancellationToken);
		return new EmployeeCreateCommandResponse(command.Employee.Id);
	}
}