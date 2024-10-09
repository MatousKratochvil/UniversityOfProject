using Core.ValueObjects;

namespace Core.CompositeValueObjects;

/// <summary>
/// Value object to represent an address.
/// </summary>
public sealed record Address
{
    public Street Street { get; }
    public City City { get; }
    public AddressState State { get; }
    public ZipCode ZipCode { get; }

    public Address(Street street, City city, AddressState state, ZipCode zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public static Address CreateBasic(string street, string city, string state, string zipCode)
        => new(
            new Street(street, BasicValidator),
            new City(city, BasicValidator),
            new AddressState(state, BasicValidator),
            new ZipCode(zipCode, BasicValidator, CoreRegex.CheckForLetters())
        );

    private static void BasicValidator(string street, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(street, 2, 50, propertyName);
}