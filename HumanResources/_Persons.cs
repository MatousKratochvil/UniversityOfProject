using Core;
using Core.CompositeValueObjects;
using Core.ValueObjects;

namespace HumanResources;

public sealed record AdministrativeEmployee(PersonTitle Title, PersonName Name, Address Address) : Person(Title, Name, Address);

public sealed record Employee(PersonTitle Title, PersonName Name, Address Address) : Person(Title, Name,Address);

public sealed record Professor(PersonTitle Title, PersonName Name, Address Address) : Person(Title, Name,Address);