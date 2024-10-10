using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.EntityFramework;

public static class Injections
{
    public static IServiceCollection AddHumanResourcesEntityFramework(this IServiceCollection services)
    {
        //services.AddDbContextPool<HumanResourcesContext>();
        return services;
    }
}