using Notifications.Persistence.Models;

namespace Notifications.Api.Dto;

public sealed class NotificationDto
{
    public required NotificationType Type { get; init; }
    public required string Content { get; init; }
    public required string Receiver { get; init; }
    public required NotificationStatus Status { get; init; }
}
