using ApiPaisesProyecto.BaseDatos;
using ApiPaisesProyecto.Entidades;
using ApiPaisesProyecto.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// A-Agregar servicios a la aplicacion.

builder.Services.AddControllers(); // Modelo-Vista-Controlador (MVC) para APIs
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Esto es Swagger/OpenAPI para documentar la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3- Configurar la conexión a la base de datos
builder.Services.AddDbContext<ContextoBaseDatos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias para el servicio de saludo
builder.Services.AddSingleton<ISaludo, Saludo>();


var app = builder.Build();

// Seeding de datos de Apartamento y migración automática solo en desarrollo
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContextoBaseDatos>();
    if (app.Environment.IsDevelopment())
    {
        db.Database.Migrate();
    }
    if (!db.Apartamentos.Any())
    {
        db.Apartamentos.AddRange(
            new Apartamento { Nombre = "Apartamento 1", Ciudad = "Ciudad A", Puerta = "A1" },
            new Apartamento { Nombre = "Apartamento 2", Ciudad = "Ciudad B", Puerta = "B2" },
            new Apartamento { Nombre = "Apartamento 3", Ciudad = "Ciudad C", Puerta = "C3" }
        );
        db.SaveChanges();
    }
}

// B-Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGet("/", () => "¡Hola, mundo! Esta es una API de ejemplo para países y apartamentos.");
//app.UseWelcomePage();



app.Run();
