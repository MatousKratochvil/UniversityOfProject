using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class StateConverter(StateValidator validator) :
    ValueConverter<State, string>(
        singleName => singleName.Value,
        value => new State(value, validator, null)
    );