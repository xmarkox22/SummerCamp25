namespace Contracts
{
    public class OrderRequestDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerEmail { get; set; } = "";
    }
}
