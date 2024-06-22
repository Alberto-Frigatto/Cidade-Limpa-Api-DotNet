using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Repository;
using CidadeLimpa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

/*adicionando os repositories*/ 
builder.Services.AddScoped<ILixeiraRepository, LixeiraRepository>();
builder.Services.AddScoped<ILixeiraParaColetaRepository, LixeiraParaColetaRepository>();

/*adicionando os services*/
builder.Services.AddScoped<ILixeiraService, LixeiraService>();
builder.Services.AddScoped<ILixeiraParaColetaService,  LixeiraParaColetaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
