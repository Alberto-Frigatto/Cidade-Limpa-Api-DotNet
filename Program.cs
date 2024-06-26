using AutoMapper;
using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;
using CidadeLimpa.Repository;
using CidadeLimpa.Services;
using CidadeLimpa.ViewModels.In;
using CidadeLimpa.ViewModels.Output;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<DatabaseContext>(
            opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
        );

        var mapperConfig = new AutoMapper.MapperConfiguration(c =>
        {
            c.AllowNullCollections = true;
            c.AllowNullDestinationValues = true;

            c.CreateMap<CreateLixeiraViewModel, LixeiraModel>();
            c.CreateMap<UpdateLixeiraViewModel, LixeiraModel>();
            c.CreateMap<LixeiraModel, DisplayLixeiraViewModel>();

            c.CreateMap<CreateLixeiraParaColetaViewModel, LixeiraParaColetaModel>();
            c.CreateMap<UpdateLixeiraParaColetaViewModel, LixeiraParaColetaModel>();
            c.CreateMap<LixeiraParaColetaModel, DisplayLixeiraParaColetaViewModel>();

            c.CreateMap<InUsuarioViewModel, UsuarioModel>();

            c.CreateMap<PontoColetaModel, DisplayPontoColetaViewModel>();

            c.CreateMap<InRotaViewModel, RotaModel>();
            c.CreateMap<RotaModel, DisplayRotaViewModel>();

            c.CreateMap<InCaminhaoViewModel, CaminhaoModel>();
            c.CreateMap<CaminhaoModel, DisplayCaminhaoViewModel>();

            c.CreateMap<InColetaViewModel, ColetaModel>();
            c.CreateMap<ColetaModel, DisplayColetaViewModel>();
        });

        IMapper mapper = mapperConfig.CreateMapper();

        builder.Services.AddSingleton(mapper);

        /*adicionando os repositories*/
        builder.Services.AddScoped<ILixeiraRepository, LixeiraRepository>();
        builder.Services.AddScoped<ILixeiraParaColetaRepository, LixeiraParaColetaRepository>();
        builder.Services.AddScoped<IPontoColetaRepository, PontoColetaRepository>();
        builder.Services.AddScoped<IRotaRepository, RotaRepository>();
        builder.Services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
        builder.Services.AddScoped<IColetaRepository, ColetaRepository>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        /*adicionando os services*/
        builder.Services.AddScoped<ILixeiraService, LixeiraService>();
        builder.Services.AddScoped<ILixeiraParaColetaService, LixeiraParaColetaService>();
        builder.Services.AddScoped<IPontoColetaService, PontoColetaService>();
        builder.Services.AddScoped<IRotaService, RotaService>();
        builder.Services.AddScoped<ICaminhaoService, CaminhaoService>();
        builder.Services.AddScoped<IColetaService, ColetaService>();
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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
    }
}