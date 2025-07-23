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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
