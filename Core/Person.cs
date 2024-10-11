using Core.ValueObjects;

namespace Core;

public sealed record Person(
    Title? Title,
    PersonName Name,
    PersonIdentification Identification,
    Address Address,
    ContactInformation ContactInformation
)
{
    private Person() : this(default!, default!, default!, default!, default!)
    {
    }
}