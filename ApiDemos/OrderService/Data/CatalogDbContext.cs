// Data/OrderDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace OrderService.Data;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
{
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<OutboxEventEntity> Outbox => Set<OutboxEventEntity>(); // opcional para mostrar patrón Outbox simplificado
}

public class OrderEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; } = "";
    public DateTime CreatedAtUtc { get; set; }
    public string Status { get; set; } = "CREATED";
}

public class OutboxEventEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrderId { get; set; }
    public string Type { get; set; } = "OrderCreatedEventDto";
    public string PayloadJson { get; set; } = ""; // para demo; en real sería serializado
    public bool Dispatched { get; set; } = false;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
