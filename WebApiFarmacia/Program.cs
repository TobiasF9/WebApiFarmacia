using WebApiMedicines;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Model.Helper;

var builder = WebApplication.CreateBuilder(args);

var appSettingsSection = builder.Configuration.GetSection("AppSettings");

builder.Services.Configure<AppSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings?.Key);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



//ValidateIssuerSigninKey Vuelve a generar la firma valida
//configuracion Serilog
string logsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
Directory.CreateDirectory(logsFolder);
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.File(Path.Combine(logsFolder, "logs.txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

// Inyectamos el contexto nuestro (clase que hereda de DbContext) con el metodo AddDbContext() y le pasamos por parametro la ConnectionString definida en el archivo appsettings.json
builder.Services.AddDbContext<MedicinesAPIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Hacemos la inyeccion de dependencia de nuestros servicios mediante una clase middleware "CompositeRoot"
CompositeRoot.DependencyInjection(builder);

// Add services to the container.
builder.Services.AddLogging(loggingBuilder => { loggingBuilder.ClearProviders(); loggingBuilder.AddSerilog(); });
//builder.Services.UseSqlServer(builder.Configuration.GetConnectionString("");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
