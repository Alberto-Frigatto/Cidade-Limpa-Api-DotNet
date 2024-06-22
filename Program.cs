using AutoMapper;
using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;
using CidadeLimpa.Repository;
using CidadeLimpa.Services;
using CidadeLimpa.ViewModels.In;
using CidadeLimpa.ViewModels.Output;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

var mapperConfig = new AutoMapper.MapperConfiguration(c => {
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<CreateLixeiraViewModel, LixeiraModel>();
    c.CreateMap<UpdateLixeiraViewModel, LixeiraModel>();
    c.CreateMap<LixeiraModel, DisplayLixeiraViewModel>();

    c.CreateMap<CreateLixeiraParaColetaViewModel, LixeiraParaColetaModel>();
    c.CreateMap<UpdateLixeiraParaColetaViewModel, LixeiraParaColetaModel>();
    c.CreateMap<LixeiraParaColetaModel, DisplayLixeiraParaColetaViewModel>();
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

/*adicionando os repositories*/
builder.Services.AddScoped<ILixeiraRepository, LixeiraRepository>();
builder.Services.AddScoped<ILixeiraParaColetaRepository, LixeiraParaColetaRepository>();

/*adicionando os services*/
builder.Services.AddScoped<ILixeiraService, LixeiraService>();
builder.Services.AddScoped<ILixeiraParaColetaService, LixeiraParaColetaService>();

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
