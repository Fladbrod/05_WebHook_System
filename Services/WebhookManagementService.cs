using System.Text;
using _05_WebHook_System_Exposee.Models;
using _05_WebHook_System_Exposee.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _05_WebHook_System_Exposee.Services;

public class WebhookManagementService : IWebhookManagementService
{
    private readonly WebhookDbContext _context;

    public WebhookManagementService(WebhookDbContext context)
    {
        _context = context;
    }

    public async Task AddSubscriptionAsync(WebhookSubscription subscription)
    {
        await _context.WebhookSubscriptions.AddAsync(subscription);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveSubscriptionAsync(Guid id)
    {
        var subscription = await _context.WebhookSubscriptions.FindAsync(id);
        if (subscription != null)
        {
            _context.WebhookSubscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
        }
    }

    public async Task InvokeWebhooksAsync(WebhookEvent webhookEvent)
    {
        // Filter the subscriptions based on the event type
        var relevantSubscriptions = await _context.WebhookSubscriptions
            .Where(sub => sub.EventTypes.Contains(webhookEvent.Type))
            .ToListAsync();

        foreach (var subscription in relevantSubscriptions)
        {
            using var httpClient = new HttpClient();
            var content = new StringContent(webhookEvent.Payload, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(subscription.Url, content);
        }
    }
}