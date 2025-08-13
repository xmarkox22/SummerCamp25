// Data/OrderEntity.cs
namespace OrderService.Data;

public class OrderEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; } = "";
    public DateTime CreatedAtUtc { get; set; }
    public string Status { get; set; } = "CREATED";
}
