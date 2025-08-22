using System.Net;
using System.Net.Http.Json;
using Contracts;
using FluentAssertions;

namespace OrderService.Tests;

public class OrdersControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public OrdersControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CreateOrder_Should_Return_Created_With_OrderId()
    {
        var client = _factory.CreateClient(new() { BaseAddress = new Uri("http://localhost:5002") });

        var req = new OrderRequestDto
        {
            ProductId = Guid.NewGuid(),
            Quantity = 1,
            CustomerEmail = "test@contoso.com"
        };

        var response = await client.PostAsJsonAsync("/api/orders", req);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var dto = await response.Content.ReadFromJsonAsync<OrderResponseDto>();
        dto.Should().NotBeNull();
        dto!.OrderId.Should().NotBeEmpty();
        dto!.Status.Should().Be("CREATED");
    }

    [Fact]
    public async Task Health_Should_Return_Ok()
    {
        var client = _factory.CreateClient(new() { BaseAddress = new Uri("http://localhost:5002") });
        var response = await client.GetAsync("/api/orders/health");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
