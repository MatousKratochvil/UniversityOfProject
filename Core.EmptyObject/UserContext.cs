using System.Globalization;
using Core.Abstractions;

namespace Core.EmptyObject;

public sealed class EmptyUserContext : IUserContext
{
	public CultureInfo Culture { get; } = new("en-US");
	public User User { get; } = new EmptyUser();
}

public sealed class TestUserContext : IUserContext
{
	public CultureInfo Culture { get; } = new("en-US");
	public User User { get; } = new TestUser();
}