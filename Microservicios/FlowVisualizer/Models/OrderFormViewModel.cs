using System.ComponentModel.DataAnnotations;

namespace FlowVisualizer.Models;

public class OrderFormViewModel
{
    [Required]
    public string ProductId { get; set; } = "df28e7a7-6d79-4783-bf62-f92362146c3b";

    [Range(1, 1000)]
    public int Quantity { get; set; } = 1;

    [EmailAddress]
    public string CustomerEmail { get; set; } = "mail@mail.com";

    // Output
    public string? MermaidDiagram { get; set; }
    public string? OrderId { get; set; }
}
