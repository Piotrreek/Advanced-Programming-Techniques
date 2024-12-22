using Notifications.Persistence.Models;

namespace Notifications.Api.Requests;

public sealed class CreateNotificationRequest
{
    public required string Content { get; init; }
    public required NotificationType Type { get; init; }
    public required string Receiver { get; init; }
    public required DateTimeOffset? PublishDateTime { get; init; }
}
