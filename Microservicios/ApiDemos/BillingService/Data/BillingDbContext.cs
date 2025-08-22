// Data/BillingDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace BillingService.Data;

public class BillingDbContext(DbContextOptions<BillingDbContext> options) : DbContext(options)
{
    public DbSet<ChargeEntity> Charges => Set<ChargeEntity>();
}
