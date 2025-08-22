// Data/OrderDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace OrderService.Data;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
{
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<OutboxEventEntity> Outbox => Set<OutboxEventEntity>(); // opcional para mostrar patrón Outbox simplificado
}
