using _05_WebHook_System_Exposee.Models;
using _05_WebHook_System_Exposee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _05_WebHook_System_Exposee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WebhookController : ControllerBase
{
    private readonly IWebhookManagementService _webhookManagementService;

    public WebhookController(IWebhookManagementService webhookManagementService)
    {
        _webhookManagementService = webhookManagementService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterWebhook([FromBody] WebhookSubscription subscription)
    {
        await _webhookManagementService.AddSubscriptionAsync(subscription);
        return Ok(subscription.Id);
    }

    [HttpDelete("unregister/{id}")]
    public async Task<IActionResult> UnregisterWebhook(Guid id)
    {
        await _webhookManagementService.RemoveSubscriptionAsync(id);
        return Ok();
    }

    [HttpPost("ping")]
    public async Task<IActionResult> PingWebhooks()
    {
        var testEvent = new WebhookEvent
        {
            Type = "ping",
            Payload = "{\"message\": \"This is a test webhook event from ping.\"}"
        };
        await _webhookManagementService.InvokeWebhooksAsync(testEvent);
        return Ok();
    }
}