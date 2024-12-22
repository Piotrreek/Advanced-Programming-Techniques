namespace Notifications.Persistence.Models;

public sealed class Notification
{
    public Guid Id { get; private set; }
    public NotificationType Type { get; private set; }
    public string Content { get; private set; }
    public string Receiver { get; private set; }
    public NotificationStatus Status { get; private set; }
    public DateTimeOffset? PublishDateTime { get; private set; }

    private Notification(Guid id, NotificationType type, string content, string receiver, NotificationStatus status,
        DateTimeOffset? publishDateTime)
    {
        Id = id;
        Type = type;
        Content = content;
        Receiver = receiver;
        Status = status;
        PublishDateTime = publishDateTime;
    }

    private Notification()
    {
    }

    public static Notification Create(NotificationType type, string content, string receiver,
        DateTimeOffset? publishDateTime)
    {
        return new Notification(Guid.NewGuid(), type, content, receiver, NotificationStatus.Created, publishDateTime);
    }
}
