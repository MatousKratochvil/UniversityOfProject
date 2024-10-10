using Core.Abstractions;
using Core.ValueObjects;
using HumanResources.Abstractions;
using MediatR;

namespace HumanResources.Commands;

public sealed record CreateEmployeeRequest : IRequest<CreateEmployeeResponse>
{
    public required string Title { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
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
        var employee = new Employee(
            new EmployeeId(Guid.NewGuid()),
            new Title(request.Title),
            new PersonName(
                new SingleName(request.FirstName),
                null,
                new SingleName(request.LastName)
            ),
            new Address(
                new Street(request.Street),
                new City(request.City),
                new State(request.State),
                new ZipCode(request.ZipCode)
            ),
            new ContactInformation(
                new Email(request.Email),
                new PhoneNumber(request.PhoneNumber)
            )
        );

        context.Employees.Add(employee);
        await context.SaveChangesAsync(cancellationToken);

        return new CreateEmployeeResponse { Id = employee.Id };
    }
}