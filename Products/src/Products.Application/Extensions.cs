using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Behaviors;

namespace Products.Application;

public static class Extensions
{
    private static Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(CurrentAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(CurrentAssembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        return services;
    }
}