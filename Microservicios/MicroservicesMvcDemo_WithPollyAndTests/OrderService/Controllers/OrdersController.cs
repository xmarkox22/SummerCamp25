using System.Net.Http.Json;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(
    IHttpClientFactory httpFactory,
    OrderDbContext db) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<OrderResponseDto>> Create([FromBody] OrderRequestDto req)
    {
        var catalog = httpFactory.CreateClient("catalog");

        var product = await catalog.GetFromJsonAsync<ProductDto>($"/api/products/{req.ProductId}");
        if (product is null) return NotFound("Producto no encontrado");
        if (product.Stock < req.Quantity) return BadRequest("Stock insuficiente");

        var order = new OrderEntity
        {
            Id = Guid.NewGuid(),
            ProductId = req.ProductId,
            Quantity = req.Quantity,
            CustomerEmail = req.CustomerEmail,
            CreatedAtUtc = DateTime.UtcNow,
            Status = "CREATED"
        };
        await db.Orders.AddAsync(order);

        await db.Outbox.AddAsync(new OutboxEventEntity
        {
            OrderId = order.Id,
            PayloadJson = "{}"
        });

        await db.SaveChangesAsync();

        return Ok(new OrderResponseDto { OrderId = order.Id, Status = order.Status });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderResponseDto>> Get(Guid id)
    {
        var o = await db.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return o is null
            ? NotFound()
            : Ok(new OrderResponseDto { OrderId = o.Id, Status = o.Status });
    }

    [HttpGet("health")]
    public IActionResult Health() => Ok("ok");
}
