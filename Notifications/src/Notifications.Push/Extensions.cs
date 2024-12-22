using Microsoft.Extensions.DependencyInjection;
using Notifications.Shared.Abstractions.Abstractions;

namespace Notifications.Push;

public static class Extensions
{
    public static IServiceCollection AddPushNotifications(this IServiceCollection services)
    {
        services.AddScoped<INotificationPublisher, PushPublisher>();
        services.AddScoped<IPushSender, PushSender>();

        return services;
    }
}
