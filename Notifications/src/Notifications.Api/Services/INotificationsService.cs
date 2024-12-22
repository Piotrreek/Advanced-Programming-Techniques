using Notifications.Api.Dto;
using Notifications.Api.Requests;
using Notifications.Persistence.Models;

namespace Notifications.Api.Services;

public interface INotificationsService
{
    Task Add(CreateNotificationRequest request);
    Task<IReadOnlyCollection<NotificationDto>> GetAll();
    Task Update(Guid notificationId, NotificationStatus status);
}
