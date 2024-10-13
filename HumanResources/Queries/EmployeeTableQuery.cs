using HumanResources.Abstractions;
using HumanResources.Entities;
using MediatR;

namespace HumanResources.Queries;

public sealed record EmployeeTableQuery(int Skip, int Take) : IRequest<EmployeeTableQueryResponse>;

public sealed record EmployeeTableQueryResponse(IList<Employee> Employees);

internal sealed class EmployeeTableQueryHandler(IHumanResourcesDbContext dbContext)
	: IRequestHandler<EmployeeTableQuery, EmployeeTableQueryResponse>
{
	public Task<EmployeeTableQueryResponse> Handle(EmployeeTableQuery request, CancellationToken cancellationToken)
	{
		var employees = dbContext.ReadFullEmployees.Query()
			.Skip(request.Skip)
			.Take(request.Take)
			.ToList();

		return Task.FromResult(new EmployeeTableQueryResponse(employees));
	}
}