using HumanResources.Abstractions;
using HumanResources.Entities;
using MediatR;

namespace HumanResources.Queries;

public sealed record EmployeeDetailQuery(EmployeeId Id) : IRequest<EmployeeDetailQueryResponse>;

public sealed record EmployeeDetailQueryResponse(Employee Employee);

internal sealed class EmployeeDetailQueryHandler(IHumanResourcesDbContext dbContext)
    : IRequestHandler<EmployeeDetailQuery, EmployeeDetailQueryResponse>
{
    public Task<EmployeeDetailQueryResponse> Handle(EmployeeDetailQuery request, CancellationToken cancellationToken)
    {
        var employee = dbContext.ReadEmployees.Query()
            .FirstOrDefault(e => e.Id == request.Id);

        return Task.FromResult(new EmployeeDetailQueryResponse(employee));
    }
}