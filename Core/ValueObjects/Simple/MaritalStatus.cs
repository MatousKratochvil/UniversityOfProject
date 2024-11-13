using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct Married : IMaritalStatus;

public record struct Single : IMaritalStatus;

public record struct Divorced : IMaritalStatus;

public record struct Widowed : IMaritalStatus;

public record struct Separated : IMaritalStatus;