using Contracts;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
}

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public static class ProductMaps
{
    public static ProductDto ToDto(this ProductEntity e) => new()
    {
        Id = e.Id, Name = e.Name, Price = e.Price, Stock = e.Stock
    };
}
