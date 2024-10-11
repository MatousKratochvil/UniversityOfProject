using Core.Abstractions;
using Core.Extensions;
using HumanResources.Events;
using HumanResources.Formatters;
using MediatR;

namespace HumanResources.Notifications;

internal sealed class EmployeeCreatedHandler(IEmailService emailService) :
    INotificationHandler<EmployeeCreated>
{
    public Task Handle(EmployeeCreated notification, CancellationToken cancellationToken)
        =>
            // TODO: upravit text emailu tak aby to byl skutecne vitani
            emailService.SendEmailAsync(
                notification.Employee.Person.ContactInformation.Email,
                $"Welcome {notification.Employee.Person.Format(PersonFullNameFormatter.Instance)} to the university!",
                "You have been successfully added to the university's employee list.",
                cancellationToken);
}