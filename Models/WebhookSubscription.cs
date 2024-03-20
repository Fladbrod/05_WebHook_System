namespace _05_WebHook_System_Exposee.Models;

public class WebhookSubscription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Url { get; set; }
    public List<string> EventTypes { get; set; }
}
