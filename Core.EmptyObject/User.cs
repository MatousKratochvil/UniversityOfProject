namespace Core.EmptyObject;

public sealed record EmptyUser() : User(string.Empty, string.Empty);

public sealed record TestUser() : User("Test User", "test@test.test");