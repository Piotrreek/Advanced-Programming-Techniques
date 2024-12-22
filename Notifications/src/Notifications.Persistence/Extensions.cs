using Microsoft.Extensions.DependencyInjection;
using Notifications.Persistence.Repositories;

namespace Notifications.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<INotificationsRepository, NotificationsRepository>();

        return services;
    }
}
