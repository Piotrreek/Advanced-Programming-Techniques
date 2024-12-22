using Notifications.Persistence.Models;

namespace Notifications.Shared.Abstractions.Abstractions;

public interface INotificationPublisher
{
    bool ShouldBeApplied(Notification notification);
    void Publish(Notification notification);
}
