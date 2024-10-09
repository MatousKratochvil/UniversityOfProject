using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class CityConverter(CityValidator validator) :
    ValueConverter<City, string>(
        city => city.Value,
        value => new City(value, validator, null)
    );