using Microsoft.EntityFrameworkCore;
using OceanGuard.Data;
using OceanGuard.Interfaces;
using OceanGuard.Repository;
using OceanGuard;
using OceanGuard.Helper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// Repositórios
builder.Services.AddScoped<IAutoridadeRepository, AutoridadeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IOcorrenciaLixoRepository, OcorrenciaLixoRepository>();
builder.Services.AddScoped<IEventoNaturalRepository, EventoNaturalRepository>();
builder.Services.AddScoped<IDensidadeBanhistaRepository, DensidadeBanhistaRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=RM96331;Password=251203;");
});
builder.Services.AddScoped<Seed>();

var app = builder.Build();

//if (args.Length == 1 && args[0].ToLower() == "seeddata")
//    SeedData(app);

//void SeedData(IHost app)
//{
//    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//    using (var scope = scopedFactory.CreateScope())
//    {
//        var service = scope.ServiceProvider.GetService<Seed>();
//        service.SeedDataContext();
//    }
//}

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
