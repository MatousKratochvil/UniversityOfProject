using Core.Abstractions;
using Core.ValueObjects;

namespace Core.ComplexObjects;

public abstract record Period(IPastDate Start, IFutureDate End) : IComplexObject;

public sealed record ValidPeriod(IPastDate Start, IFutureDate End) : Period(Start, End);

public sealed record InvalidPeriod(IPastDate Start, IFutureDate End) : Period(Start, End);