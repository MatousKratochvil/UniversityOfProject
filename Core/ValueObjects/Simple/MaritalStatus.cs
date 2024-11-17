namespace Core.ValueObjects.Simple;

public abstract record MaritalStatus
{
	public static string ToRepresentation(MaritalStatus status) =>
		status switch
		{
			Unspecified _ => nameof(Unspecified),
			Married _ => nameof(Married),
			Single _ => nameof(Single),
			Divorced _ => nameof(Divorced),
			Widowed _ => nameof(Widowed),
			Separated _ => nameof(Separated),
			_ => throw new ArgumentException($"Unknown marital status: {status}")
		};

	public static MaritalStatus FromRepresentation(string s) =>
		s switch
		{
			nameof(Unspecified) => new Unspecified(),
			nameof(Married) => new Married(),
			nameof(Single) => new Single(),
			nameof(Divorced) => new Divorced(),
			nameof(Widowed) => new Widowed(),
			nameof(Separated) => new Separated(),
			_ => throw new ArgumentException($"Unknown marital status: {s}")
		};

	public sealed record Unspecified : MaritalStatus;

	public sealed record Married : MaritalStatus;

	public sealed record Single : MaritalStatus;

	public sealed record Divorced : MaritalStatus;

	public sealed record Widowed : MaritalStatus;

	public sealed record Separated : MaritalStatus;
}