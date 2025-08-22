﻿// Background/BackgroundDispatcher.cs
using System.Net.Http.Json;
using Contracts;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;

namespace OrderService.Background;

public class BackgroundDispatcher(
    IHttpClientFactory httpClientFactory,
    IServiceProvider sp,
    EndpointUrls urls) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var billing = httpClientFactory.CreateClient("billing");

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<OrderDbContext>();

            // Saca un lote pequeño de eventos no despachados
            var pending = await db.Outbox.Where(o => !o.Dispatched)
                                         .OrderBy(o => o.CreatedAtUtc)
                                         .Take(10)
                                         .ToListAsync(stoppingToken);

            foreach (var e in pending)
            {
                try
                {
                    // Para demo, reconstruimos el DTO mínimo (payload no se usa aquí)
                    var order = await db.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == e.OrderId, stoppingToken);
                    if (order is null) { e.Dispatched = true; continue; }

                    var dto = new OrderCreatedEventDto
                    {
                        OrderId = order.Id,
                        ProductId = order.ProductId,
                        Quantity = order.Quantity,
                        CustomerEmail = order.CustomerEmail,
                        CreatedAtUtc = order.CreatedAtUtc
                    };

                    var resp = await billing.PostAsJsonAsync(urls.BillingWebhookUrl, dto, stoppingToken);
                    if (resp.IsSuccessStatusCode) e.Dispatched = true;
                }
                catch
                {
                    // Silenciar/registrar; se reintentará en el siguiente ciclo
                }
            }

            await db.SaveChangesAsync(stoppingToken);
            await Task.Delay(10000, stoppingToken);
        }
    }
}
