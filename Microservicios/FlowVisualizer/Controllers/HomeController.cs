using FlowVisualizer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowVisualizer.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var model = new OrderFormViewModel
        {
            ProductId = "df28e7a7-6d79-4783-bf62-f92362146c3b",
            Quantity = 1,
            CustomerEmail = "mail@mail.com"
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(OrderFormViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        var orderId = Guid.NewGuid().ToString();
        var productId = model.ProductId;
        var qty = model.Quantity;
        var email = model.CustomerEmail;
        var now = DateTime.UtcNow.ToString("u");

        // Simulated timings
        var t1 = Random.Shared.Next(20, 120);
        var t2 = Random.Shared.Next(20, 120);

        // Mermaid sequence diagram (simulation)
        var mermaid = $@"
sequenceDiagram
    participant Client as Client (Postman/UI)
    participant OrderService
    participant CatalogService
    participant BillingService

    Client->>OrderService: POST /api/orders\n{{""productId"":""{productId}"",""quantity"":{qty},""email"":""{email}""}}
    Note right of OrderService: Recibido {now} (OrderId {orderId})

    OrderService->>CatalogService: GET /api/products/{productId}
    CatalogService-->>OrderService: 200 OK ({t1} ms) + Stock

    OrderService->>BillingService: POST /api/billing/charge (webhook)
    BillingService-->>OrderService: 200 OK ({t2} ms)

    Note over OrderService,BillingService: Evento encolado (outbox) y despachado asíncronamente
";

        model.MermaidDiagram = mermaid;
        model.OrderId = orderId;
        return View("Index", model);
    }
}
