using Core;
using Core.ValueObjects;

namespace HumanResources;

public sealed record AdministrativeEmployee(Title Title, PersonName Name, Address Address, ContactInformation ContactInformation) 
    : Person(Title, Name, Address, ContactInformation);

public sealed record Employee(Title Title, PersonName Name, Address Address, ContactInformation ContactInformation)
    : Person(Title, Name,Address, ContactInformation);

public sealed record Professor(Title Title, PersonName Name, Address Address, ContactInformation ContactInformation) 
    : Person(Title, Name,Address, ContactInformation);