using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class StateConverter(StateValidator validator) :
    ValueConverter<AddressState, string>(
        singleName => singleName.Value,
        value => new AddressState(value, validator, null)
    );