using Hangfire;
using Notifications.Persistence.Models;
using Notifications.Persistence.Repositories;
using Notifications.Shared.Abstractions.Abstractions;

namespace Notifications.Api.Jobs;

internal sealed class NotificationsProcessor
{
    private readonly IEnumerable<INotificationPublisher> _notificationPublishers;
    private readonly INotificationsRepository _notificationsRepository;
    private readonly ILogger<NotificationsProcessor> _logger;

    public NotificationsProcessor(
        IEnumerable<INotificationPublisher> notificationPublishers,
        INotificationsRepository notificationsRepository,
        ILogger<NotificationsProcessor> logger
    )
    {
        _notificationPublishers = notificationPublishers;
        _notificationsRepository = notificationsRepository;
        _logger = logger;
    }

    public async Task ProcessAwaitingNotifications()
    {
        var notifications = (await _notificationsRepository.GetAll())
            .Where(notification => notification.Status is NotificationStatus.Created);

        foreach (var notification in notifications)
        {
            if (notification.PublishDateTime > DateTimeOffset.Now)
            {
                await ScheduleNotificationJob(notification);
                continue;
            }

            await ProcessNotification(notification);
        }
    }

    public async Task ProcessNotification(Guid notificationId)
    {
        var notification = await _notificationsRepository.GetById(notificationId);
        await ProcessNotification(notification);
    }

    private async Task ScheduleNotificationJob(Notification notification)
    {
        BackgroundJob.Schedule<NotificationsProcessor>(processor => processor.ProcessNotification(notification.Id),
            notification.PublishDateTime!.Value);
        await _notificationsRepository.Update(notification.Id, NotificationStatus.Awaiting);
    }

    private async Task ProcessNotification(Notification notification)
    {
        var publisher = _notificationPublishers.First(publisher => publisher.ShouldBeApplied(notification));

        try
        {
            publisher.Publish(notification);
            await _notificationsRepository.Update(notification.Id, NotificationStatus.Sent);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error publishing notification {NotificationId}", notification.Id);
            await _notificationsRepository.Update(notification.Id, NotificationStatus.FailedToSend);
        }
    }
}
