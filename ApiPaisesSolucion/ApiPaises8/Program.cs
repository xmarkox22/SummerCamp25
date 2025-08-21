using ApiPaisesProyecto.Contexto;
using ApiPaisesProyecto.Servicios;
using ConversorAcme.Api.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
var corsPolicyName = "AllowAngular";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var version = "Ingles";
if (version != "Ingles")
{
    builder.Services.AddTransient<ISaludo, Saludo>();
}
else
{
    builder.Services.AddTransient<ISaludo, SaludoEnIngles>();
}

// Agregar servicios de acceso a datos (Repositorio)
// Patron Repositorio
// Un repositorio es un objeto que encapsula el acceso a la capa de datos
// y oculta los detalles de cómo se accede a los datos.
// Un repositorio separa la lógica de negocio de la lógica de acceso a datos.
builder.Services.AddScoped<IGestionPaises, GestionPaisesBBDD>();

// Agregar BBDD (SQLite)
builder.Services.AddDbContext<ContextoApi>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ConversorApiPaises"));
});


var app = builder.Build();

// Rellenar la tabla de países al arrancar la aplicación
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContextoApi>();
    if (!db.Paises.Any())
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://restcountries.com/v3.1/all?fields=name,capital,languages");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var countries = System.Text.Json.JsonDocument.Parse(json).RootElement;
            var paises = new List<ConversorAcme.Api.Entidades.Pais>();
            foreach (var country in countries.EnumerateArray())
            {
                var nombre = country.GetProperty("name").GetProperty("common").GetString();
                var capital = country.TryGetProperty("capital", out var capArr) && capArr.GetArrayLength() > 0 ? capArr[0].GetString() : null;
                var idioma = country.TryGetProperty("languages", out var langs) && langs.EnumerateObject().Any() ? langs.EnumerateObject().First().Value.GetString() : null;
                paises.Add(new ConversorAcme.Api.Entidades.Pais
                {
                    Nombre = nombre ?? "",
                    Capital = capital,
                    Idioma = idioma,
                    FechaInicioTemporadaAlta = DateTime.Now,
                    FechaFinTemporadaAlta = DateTime.Now.AddMonths(1)
                });
            }
            db.Paises.AddRange(paises);
            db.SaveChanges();
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS before authorization and controllers
app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
