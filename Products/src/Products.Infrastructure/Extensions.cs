using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Infrastructure.DAL;
using Products.Infrastructure.Exceptions;

namespace Products.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddDataAccessLayer(configuration);
        services.AddSingleton<ExceptionHandlingMiddleware>();

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.MapControllers();

        return app;
    }
}