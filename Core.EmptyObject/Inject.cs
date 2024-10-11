using Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Core.EmptyObject;

public static class Inject
{
	public static IServiceCollection AddEmptyObject(this IServiceCollection services)
	{
		services.AddSingleton<IUserContext, EmptyUserContext>();
		services.AddSingleton<IEmailService, ConsoleEmailService>();
		return services;
	}
}