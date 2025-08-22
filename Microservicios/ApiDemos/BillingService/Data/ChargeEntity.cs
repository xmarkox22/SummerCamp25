// Data/BillingDbContext.cs
namespace BillingService.Data;

public class ChargeEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrderId { get; set; }
    public DateTime ChargedAtUtc { get; set; } = DateTime.UtcNow;
}
