using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Contracts;

namespace OrderService.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<global::Program>
{
    protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Re-registrar el HttpClient "catalog" con un handler simulado
            services.AddHttpClient("catalog")
                .ConfigurePrimaryHttpMessageHandler(() => new StubCatalogHandler());
        });
    }

    private class StubCatalogHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri is null) return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest));

            // Simula GET /api/products/{id}
            if (request.Method == HttpMethod.Get && request.RequestUri.AbsolutePath.StartsWith("/api/products/"))
            {
                var dto = new ProductDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Fake Product",
                    Price = 10,
                    Stock = 10
                };
                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = JsonContent.Create(dto)
                };
                return Task.FromResult(resp);
            }

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
    }
}
