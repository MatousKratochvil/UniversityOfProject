using HumanResources.Abstractions;
using HumanResources.Entities;
using MediatR;

namespace HumanResources.Queries;

public sealed record DetailEmployeeQuery(EmployeeId Id) : IRequest<DetailEmployeeQueryResponse>;

public sealed record DetailEmployeeQueryResponse(Employee Employee);

internal sealed class DetailEmployeeQueryHandler(IHumanResourcesDbContext dbContext)
    : IRequestHandler<DetailEmployeeQuery, DetailEmployeeQueryResponse>
{
    public Task<DetailEmployeeQueryResponse> Handle(DetailEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = dbContext.ReadEmployees.Query()
            .FirstOrDefault(e => e.Id == request.Id);

        return Task.FromResult(new DetailEmployeeQueryResponse(employee));
    }
}