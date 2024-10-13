using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Products.Abstractions;
using Products.Infrastructure.DAL.Behaviors;
using Products.Infrastructure.DAL.Interceptors;
using Products.Infrastructure.DAL.Repositories;

namespace Products.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<DatabaseInitializer>();

        services.AddSingleton<AuditProductChangesInterceptor>();
        services.AddDbContext<ProductsContext>((sp, builder) =>
        {
            var auditProductChangesInterceptor = sp.GetRequiredService<AuditProductChangesInterceptor>();

            builder.UseNpgsql(configuration.GetConnectionString("ProductsConnection"))
                .AddInterceptors(auditProductChangesInterceptor);
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        return services;
    }
}