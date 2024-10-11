using HumanResources.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources;

public static class Injections
{
    public static IServiceCollection AddHumanResources(this IServiceCollection services)
    {
        services.AddScoped<IHumanResourceFactory, HumanResourceFactory>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Injections).Assembly));
        return services;
    }
}