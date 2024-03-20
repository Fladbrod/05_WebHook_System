using Microsoft.EntityFrameworkCore;
using _05_WebHook_System_Exposee.Models;

public class WebhookDbContext : DbContext
{
    public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }

    public WebhookDbContext(DbContextOptions<WebhookDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WebhookSubscription>()
            .HasKey(c => c.Id);
    }
}