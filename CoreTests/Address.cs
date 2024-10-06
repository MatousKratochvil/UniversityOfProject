using Core;

namespace CoreTests;

public class AddressTest
{
    [Theory]
    [InlineData("123 Main St", "Springfield", "IL", "62701")]
    [InlineData("123 Main St", "Springfield", "IL", "62701-1234")]
    public void Create_WithValidArguments_ReturnsAddressType(string street, string city, string state, string zipCode)
    {
        var address = Address.Create(street, city, state, zipCode);

        Assert.Equal(street, address.Street);
        Assert.Equal(city, address.City);
        Assert.Equal(state, address.State);
        Assert.Equal(zipCode, address.ZipCode);
    }
    
    [Theory]
    [InlineData("1", "Springfield", "IL", "62701")]
    [InlineData("123 Main St", "S", "IL", "62701")]
    [InlineData("123 Main St", "Springfield", "I", "62701")]
    [InlineData("123 Main St", "Springfield", "IL", "6270")]
    [InlineData("123 Main St Springfield Alabama Texas Arizona Washington", "Springfield", "IL", "627")]
    [InlineData("123 Main St", "Springfield Mississippi Alabama Texas Arizona Washington", "IL", "627")]
    [InlineData("123 Main St", "Springfield", "IL North Carolina Mississippi Alabama Texas Arizona Washington", "627")]
    [InlineData("123 Main St", "Springfield", "IL", "627 North Carolina Mississippi Alabama Texas Arizona Washington")]
    public void Create_WithInvalidArguments_ThrowsArgumentException(string street, string city, string state, string zipCode)
    {
        Assert.Throws<ArgumentException>(() => Address.Create(street, city, state, zipCode));
    }
}