using WebApiMedicines;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
