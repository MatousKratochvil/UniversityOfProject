﻿using HumanResources.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HumanResources.EntityFramework;

public static class Injections
{
    public static IServiceCollection AddHumanResourcesEntityFramework(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<IHumanResourcesDbContext, HumanResourcesContext>(opt =>
        {
            opt.UseSqlite("Data Source=HumanResources.db");
            //configuration.GetConnectionString("HumanResources"));
        });
        return services;
    }

    public static IHost MigrateHumanResourcesDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<HumanResourcesContext>();
        context.Database.Migrate();
        return host;
    }
}