using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.Common.Behaviors;

namespace WebApi.Application;

/// <summary>
/// Service class for dependency injection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Extension method for dependency injection
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>ServiceCollection return</returns>
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services
            .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(LoggingBehavior<,>));
        return services;
    }
}