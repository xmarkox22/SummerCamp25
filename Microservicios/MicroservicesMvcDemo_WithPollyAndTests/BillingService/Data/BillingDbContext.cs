using Microsoft.EntityFrameworkCore;

namespace BillingService.Data;

public class BillingDbContext(DbContextOptions<BillingDbContext> options) : DbContext(options)
{
    public DbSet<ChargeEntity> Charges => Set<ChargeEntity>();
}

public class ChargeEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrderId { get; set; }
    public DateTime ChargedAtUtc { get; set; } = DateTime.UtcNow;
}
