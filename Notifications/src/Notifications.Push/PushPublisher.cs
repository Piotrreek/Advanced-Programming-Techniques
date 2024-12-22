using Notifications.Persistence.Models;
using Notifications.Shared.Abstractions.Abstractions;

namespace Notifications.Push;

internal sealed class PushPublisher : INotificationPublisher
{
    private readonly IPushSender _pushSender;

    public PushPublisher(IPushSender pushSender)
    {
        _pushSender = pushSender;
    }

    public bool ShouldBeApplied(Notification notification)
    {
        return notification.Type is NotificationType.Push;
    }

    public void Publish(Notification notification)
    {
        _pushSender.Send(notification);
    }
}
