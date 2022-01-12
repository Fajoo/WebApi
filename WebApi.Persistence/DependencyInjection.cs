using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.Interfaces;

namespace WebApi.Persistence;

/// <summary>
/// Service class for injecting database layer dependency
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Extension method for dependency injection
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">Application configuration</param>
    /// <returns>ServiceCollection return</returns>
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