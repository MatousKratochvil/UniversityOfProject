using Core;
using HumanResources.Entities;
using MediatR;

namespace HumanResources.Events;

public sealed record EmployeeCreated(Employee Employee, User UserCreatedBy) : INotification;