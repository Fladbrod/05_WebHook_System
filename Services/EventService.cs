using System.Text.Json;
using _05_WebHook_System_Exposee.Models;
using _05_WebHook_System_Exposee.Services.Interfaces;

namespace _05_WebHook_System_Exposee.Services;

public class EventService
{
    private readonly IWebhookManagementService _webhookManagementService;

    public EventService(IWebhookManagementService webhookManagementService)
    {
        _webhookManagementService = webhookManagementService;
    }

    public async Task TriggerEventAsync(EventType eventType, object eventData)
    {
        var webhookEvent = new WebhookEvent
        {
            Type = eventType.ToString(),
            Payload = JsonSerializer.Serialize(eventData)
        };

        await _webhookManagementService.InvokeWebhooksAsync(webhookEvent);
    }
}