using CatalogService.Data;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(CatalogDbContext db) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> Get(Guid id)
    {
        var e = await db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        return e is null ? NotFound() : Ok(e.ToDto());
    }

    [HttpGet("health")]
    public IActionResult Health() => Ok("ok");
}
