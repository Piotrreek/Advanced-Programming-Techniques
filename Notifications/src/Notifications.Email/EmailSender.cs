using System.Text.Json;
using Microsoft.Extensions.Logging;
using Notifications.Persistence.Models;

namespace Notifications.Email;

internal sealed class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public void Send(Notification notification)
    {
        _logger.LogInformation("Sending e-mail {Email}", JsonSerializer.Serialize(notification));
    }
}
