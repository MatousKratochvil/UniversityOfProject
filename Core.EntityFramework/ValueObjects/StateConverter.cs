using Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.EntityFramework.ValueObjects;

public sealed class StateConverter() :
    ValueConverter<State, string>(
        state => state.Value,
        @string => new State(@string)
    );