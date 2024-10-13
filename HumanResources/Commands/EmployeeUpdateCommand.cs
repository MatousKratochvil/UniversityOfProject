using HumanResources.Abstractions;
using HumanResources.Entities;
using MediatR;

namespace HumanResources.Commands;

public sealed record EmployeeUpdateCommand(Employee Employee)
	: IRequest<EmployeeUpdateCommandResponse>;

public sealed record EmployeeUpdateCommandResponse(EmployeeId Id);

internal sealed class EmployeeUpdateCommandHandler(
	IHumanResourcesDbContext context,
	IHumanResourceFactory factory)
	: IRequestHandler<EmployeeUpdateCommand, EmployeeUpdateCommandResponse>
{
	public async Task<EmployeeUpdateCommandResponse> Handle(EmployeeUpdateCommand command,
		CancellationToken cancellationToken)
	{
		context.Employees.Update(command.Employee);
		await context.SaveChangesAsync(cancellationToken);

		return new EmployeeUpdateCommandResponse(command.Employee.Id);
	}
}