using Core.CompositeValueObjects;
using Core.ValueObjects;

namespace Core;

public abstract record Person(
    PersonTitle Title,
    PersonName Name,
    Address Address
);