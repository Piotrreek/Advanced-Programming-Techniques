using Notifications.Persistence.Models;
using Notifications.Shared.Abstractions.Abstractions;

namespace Notifications.Email;

internal sealed class EmailPublisher : INotificationPublisher
{
    private readonly IEmailSender _emailSender;

    public EmailPublisher(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public bool ShouldBeApplied(Notification notification)
    {
        return notification.Type is NotificationType.Email;
    }

    public void Publish(Notification notification)
    {
        _emailSender.Send(notification);
    }
}
