using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.Interfaces;

namespace WebApi.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection
        services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<WebApiDbContext>(options =>
        {
            options.UseSqlite(connectionString,
                b => b.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName));
        });
        services.AddScoped<IWebApiDbContext>(provider =>
            provider.GetService<WebApiDbContext>());
        return services;
    }
}