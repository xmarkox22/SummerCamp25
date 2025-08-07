using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// A-Agregar servicios a la aplicacion.

// Agregar servicio de Serilog
builder.Logging.AddSerilog();


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

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IGestionInmueblesService, GestionInmueblesService>();
builder.Services.AddAutoMapper(typeof(ApiPaisesProyecto.Servicios.MappingProfile));

var app = builder.Build();

// Seeding de datos de Apartamento, Edificio y Distrito, y migración automática solo en desarrollo
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContextoBaseDatos>();
    if (app.Environment.IsDevelopment())
    {
        db.Database.Migrate();
    }
    if (!db.Apartamentos.Any() && !db.Edificios.Any() && !db.Distritos.Any())
    {
        // 1. Crear 3 distritos
        var distritos = new List<Distrito>
        {
            new Distrito { Nombre = "Distrito Norte" },
            new Distrito { Nombre = "Distrito Centro" },
            new Distrito { Nombre = "Distrito Sur" }
        };
        db.Distritos.AddRange(distritos);
        db.SaveChanges();

        // 2. Crear 5 edificios, repartidos entre los distritos
        var edificioFaker = new Faker<Edificio>()
            .RuleFor(e => e.Nombre, f => $"Edificio {f.UniqueIndex + 1}")
            .RuleFor(e => e.Ciudad, f => f.Address.City())
            .RuleFor(e => e.Direccion, f => f.Address.StreetAddress())
            .RuleFor(e => e.NumeroDePisos, f => f.Random.Int(3, 15))
            .RuleFor(e => e.Distrito, f => f.PickRandom(distritos));
        var edificios = edificioFaker.Generate(5);
        db.Edificios.AddRange(edificios);
        db.SaveChanges();

        // 3. Crear 250 apartamentos, asignando edificio aleatorio
        var apartamentoFaker = new Faker<Apartamento>()
            .RuleFor(a => a.Nombre, f => $"Apartamento {f.UniqueIndex + 1}")
            .RuleFor(a => a.Ciudad, f => f.Address.City())
            .RuleFor(a => a.Puerta, f => f.Random.AlphaNumeric(3).ToUpper())
            .RuleFor(a => a.Edificio, f => f.PickRandom(edificios));
        var apartamentos = apartamentoFaker.Generate(250);
        db.Apartamentos.AddRange(apartamentos);
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
