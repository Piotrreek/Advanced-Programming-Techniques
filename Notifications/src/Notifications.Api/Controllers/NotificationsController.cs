using Microsoft.AspNetCore.Mvc;
using Notifications.Api.Requests;
using Notifications.Api.Services;

namespace Notifications.Api.Controllers;

[Route("api/v1/notifications")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationsService _notificationsService;

    public NotificationsController(INotificationsService notificationsService)
    {
        _notificationsService = notificationsService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateNotificationRequest request)
    {
        await _notificationsService.Add(request);
        return Created("", null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notifications = await _notificationsService.GetAll();
        return Ok(notifications);
    }
}
