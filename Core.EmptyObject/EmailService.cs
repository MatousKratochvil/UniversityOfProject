using Core.Abstractions;

namespace Core.EmptyObject;

public sealed class ConsoleEmailService : IEmailService
{
	public Task SendEmailAsync(string to, string subject, string body, CancellationToken cancellationToken)
	{
		Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}'");
		return Task.CompletedTask;
	}
}