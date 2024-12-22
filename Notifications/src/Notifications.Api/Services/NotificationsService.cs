using Notifications.Api.Dto;
using Notifications.Api.Requests;
using Notifications.Persistence.Models;
using Notifications.Persistence.Repositories;

namespace Notifications.Api.Services;

internal sealed class NotificationsService : INotificationsService
{
    private readonly INotificationsRepository _notificationsRepository;

    public NotificationsService(INotificationsRepository notificationsRepository)
    {
        _notificationsRepository = notificationsRepository;
    }

    public async Task Add(CreateNotificationRequest request)
    {
        var notification =
            Notification.Create(request.Type, request.Content, request.Receiver, request.PublishDateTime);
        await _notificationsRepository.Add(notification);
    }

    public async Task<IReadOnlyCollection<NotificationDto>> GetAll()
    {
        return (await _notificationsRepository.GetAll())
            .Select(notification => new NotificationDto
            {
                Type = notification.Type,
                Content = notification.Content,
                Receiver = notification.Receiver,
                Status = notification.Status
            }).ToList();
    }

    public async Task Update(Guid notificationId, NotificationStatus status)
    {
        await _notificationsRepository.Update(notificationId, status);
    }
}
