using Core.ValueObjects;

namespace Core;

/// <summary>
/// Value object to represent an address.
/// </summary>
public record Address
{
    public Street Street { get; }
    public City City { get; }
    public State State { get; }
    public ZipCode ZipCode { get; }

    private Address(Street street, City city, State state, ZipCode zipCode)
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
            new State(state, BasicValidator),
            new ZipCode(zipCode, BasicValidator, CoreRegex.CheckForLetters())
        );

    public static Address Create(Street street, City city, State state, ZipCode zipCode)
        => new(street, city, state, zipCode);

    private static void BasicValidator(string street, string? propertyName) =>
        Guard.ThrowWhenOutOfLengthRange(street, 2, 50, propertyName);
}