namespace Contracts;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class OrderRequestDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; } = "";
}

public class OrderResponseDto
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = "";
}

public class OrderCreatedEventDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; } = "";
    public DateTime CreatedAtUtc { get; set; }
}
