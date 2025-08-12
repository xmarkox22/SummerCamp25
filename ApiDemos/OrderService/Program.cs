using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OrderService.Background;
using OrderService.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config (puedes mover a appsettings.json)
var catalogBaseUrl = builder.Configuration["Catalog:BaseUrl"] ?? "http://localhost:5001";
var billingWebhookUrl = builder.Configuration["Billing:WebhookUrl"] ?? "http://localhost:5003/api/billing/charge";

// EF InMemory
builder.Services.AddDbContext<OrderDbContext>(opt =>
    opt.UseInMemoryDatabase("OrdersDb"));

// HttpClients
builder.Services.AddHttpClient("catalog", c => c.BaseAddress = new Uri(catalogBaseUrl));
builder.Services.AddHttpClient("billing");

builder.Services.AddSingleton(new EndpointUrls(catalogBaseUrl, billingWebhookUrl));
builder.Services.AddHostedService<BackgroundDispatcher>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.MapControllers();
app.Run("http://localhost:5002");

public record EndpointUrls(string CatalogBaseUrl, string BillingWebhookUrl);

