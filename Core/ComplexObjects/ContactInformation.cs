using Core.Abstractions;
using Core.ValueObjects;

namespace Core.ComplexObjects;

public sealed record ContactInformation(Email Email, PhoneNumber PhoneNumber) : IComplexObject;