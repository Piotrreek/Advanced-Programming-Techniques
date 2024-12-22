using System.Text.Json;
using Microsoft.Extensions.Logging;
using Notifications.Persistence.Models;

namespace Notifications.Push;

internal sealed class PushSender : IPushSender
{
    private readonly ILogger<PushSender> _logger;

    public PushSender(ILogger<PushSender> logger)
    {
        _logger = logger;
    }

    public void Send(Notification notification)
    {
        _logger.LogInformation("Sending push notification: {Notification}", JsonSerializer.Serialize(notification));
    }
}
