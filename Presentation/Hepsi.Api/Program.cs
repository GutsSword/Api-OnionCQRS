using Persistence;
using Hepsi.Api.Application;
using Hepsi.Mapper;
using Hepsi.Api.Application.Exceptions;
using Hepsi.Api.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment; 

builder.Configuration  
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings{env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(x =>
    {
        x.SwaggerDoc("v1", new OpenApiInfo { Title = "Youtube API", Version = "v1", Description = "Youtube API Swagger Client." });
        x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "'Bearer' Yazýp Boþluk Býraktýktan Sonra Token'i Girebilirsiniz.\r\n\r\n Örneðin: \"Bearer u6*g@@$e3!e^2l40tlm-5v25j5^1&^=39b7b2qsa0qro-8vny6\""
        }) ;
        x.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference= new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleWare();

app.UseAuthorization();

app.MapControllers();

app.Run();

