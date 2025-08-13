using Microsoft.EntityFrameworkCore;
using OrderService.Background;
using OrderService.Data;
using Polly;
using Polly.Extensions.Http;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config por defecto
var catalogBaseUrl    = builder.Configuration["Catalog:BaseUrl"]    ?? "http://localhost:5001";
var billingWebhookUrl = builder.Configuration["Billing:WebhookUrl"] ?? "http://localhost:5003/api/billing/charge";

builder.Services.AddDbContext<OrderDbContext>(opt => opt.UseInMemoryDatabase("OrdersDb"));

// Políticas Polly
var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .OrResult(msg => msg.StatusCode == (HttpStatusCode)429)
    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromMilliseconds(200 * Math.Pow(2, retryAttempt))); // 200ms,400ms,800ms

var breakerPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

builder.Services.AddHttpClient("catalog", c => c.BaseAddress = new Uri(catalogBaseUrl))
    .AddPolicyHandler(retryPolicy)
    .AddPolicyHandler(breakerPolicy);

builder.Services.AddHttpClient("billing");

builder.Services.AddSingleton(new EndpointUrls(catalogBaseUrl, billingWebhookUrl));
builder.Services.AddHostedService<BackgroundDispatcher>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run("http://localhost:5002");

public partial class Program { } // Para WebApplicationFactory (tests)
