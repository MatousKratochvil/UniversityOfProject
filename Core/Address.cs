namespace Core;

public record Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }
    
    private Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
    
    public static Address Create(string street, string city, string state, string zipCode)
    {
        Guard.ThrowWhenOutOfLengthRange(street, 2, 50);
        Guard.ThrowWhenOutOfLengthRange(city, 2, 50);
        Guard.ThrowWhenOutOfLengthRange(state, 2, 50);
        Guard.ThrowWhenOutOfLengthRange(zipCode, 5, 50);
        
        return new Address(street, city, state, zipCode);
    }
}