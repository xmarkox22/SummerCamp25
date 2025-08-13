// Data/OutboxEventEntity.cs
namespace OrderService.Data;

public class OutboxEventEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrderId { get; set; }
    public string Type { get; set; } = "OrderCreatedEventDto";
    public string PayloadJson { get; set; } = ""; // para demo; en real sería serializado
    public bool Dispatched { get; set; } = false;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
