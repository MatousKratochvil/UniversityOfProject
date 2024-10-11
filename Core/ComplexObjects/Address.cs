using Core.Abstractions;
using Core.ValueObjects;

namespace Core.ComplexObjects;

public sealed record Address(Street Street, City City, State State, ZipCode ZipCode) : IComplexObject;