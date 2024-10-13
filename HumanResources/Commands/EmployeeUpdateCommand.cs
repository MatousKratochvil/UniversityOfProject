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
		var employee = context.Employees.Query().First(x => x.Id == command.Employee.Id);
		employee.Person = command.Employee.Person;
		employee.Contract = command.Employee.Contract;

		context.Employees.Update(employee);
		await context.SaveChangesAsync(cancellationToken);

		return new EmployeeUpdateCommandResponse(employee.Id);
	}
}