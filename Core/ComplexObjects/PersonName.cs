using Core.Abstractions;
using Core.ValueObjects;

namespace Core.ComplexObjects;

public sealed record PersonName(SingleName FirstName, SingleName? MiddleName, SingleName LastName) : IComplexObject;