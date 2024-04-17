using Core.Configurations;
using Data.Configurations;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataServices();
builder.Services.RegisterCoreServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, $"{nameof(API)}.xml");
    var coreXmlPath = Path.Combine(AppContext.BaseDirectory, $"{nameof(Core)}.xml");

    c.IncludeXmlComments(apiXmlPath);
    c.IncludeXmlComments(coreXmlPath);
});

builder.Services.AddCors(options =>
{
    var corsOrigin = builder.Configuration.GetValue<string>("Cors:Origin");

    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins(corsOrigin!)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
