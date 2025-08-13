// Controllers/BillingController.cs
using BillingService.Data;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingController(BillingDbContext db) : ControllerBase
{
    [HttpPost("charge")]
    public async Task<IActionResult> Charge([FromBody] OrderCreatedEventDto evt)
    {
        var already = await db.Charges.AsNoTracking().AnyAsync(c => c.OrderId == evt.OrderId);
        if (already) return Ok(new { charged = false, reason = "duplicate", evt.OrderId });

        db.Charges.Add(new ChargeEntity { OrderId = evt.OrderId });
        await db.SaveChangesAsync();

        Console.WriteLine($"[Billing] Cobrado pedido {evt.OrderId} ({evt.Quantity} uds) a {evt.CustomerEmail}");
        return Ok(new { charged = true, evt.OrderId });
    }

    [HttpGet("health")]
    public IActionResult Health() => Ok("ok");
}
