using Core.ValueObjects;

namespace Core;

public abstract record Person(
    Title Title,
    PersonName Name,
    Address Address,
    ContactInformation ContactInformation
);