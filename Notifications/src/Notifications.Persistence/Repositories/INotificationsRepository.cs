using Notifications.Persistence.Models;

namespace Notifications.Persistence.Repositories;

public interface INotificationsRepository
{
    Task Add(Notification notification);
    Task Update(Guid notificationId, NotificationStatus status);
    Task<IReadOnlyCollection<Notification>> GetAll();
    Task<Notification> GetById(Guid notificationId);
}
