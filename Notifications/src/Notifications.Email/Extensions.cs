using Microsoft.Extensions.DependencyInjection;
using Notifications.Shared.Abstractions.Abstractions;

namespace Notifications.Email;

public static class Extensions
{
    public static IServiceCollection AddEmailNotifications(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<INotificationPublisher, EmailPublisher>();

        return services;
    }
}
