using Notifications.Persistence.Models;

namespace Notifications.Push;

internal interface IPushSender
{
    void Send(Notification notification);
}
