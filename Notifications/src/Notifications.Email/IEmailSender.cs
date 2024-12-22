using Notifications.Persistence.Models;

namespace Notifications.Email;

internal interface IEmailSender
{
    void Send(Notification notification);
}
