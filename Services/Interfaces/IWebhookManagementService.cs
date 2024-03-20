using _05_WebHook_System_Exposee.Models;

namespace _05_WebHook_System_Exposee.Services.Interfaces;

public interface IWebhookManagementService
{
    Task AddSubscriptionAsync(WebhookSubscription subscription);
    Task RemoveSubscriptionAsync(Guid id);
    Task InvokeWebhooksAsync(WebhookEvent webhookEvent);
}