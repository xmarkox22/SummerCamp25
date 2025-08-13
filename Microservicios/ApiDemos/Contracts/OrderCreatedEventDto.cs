namespace Contracts
{

    public class OrderCreatedEventDto
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerEmail { get; set; } = "";
        public DateTime CreatedAtUtc { get; set; }
    }
}
