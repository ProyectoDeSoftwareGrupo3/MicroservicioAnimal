using Application;
using Application.IMappers;
using Application.Interfaces;
using Application.Interfaces.IAnimalRaza;
using Application.Interfaces.IAnimalTipo;
using Application.Interfaces.IFoto;
using Application.Mappers;
using Application.UseCases;
using Infrastructure;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
//            ValidAudience = builder.Configuration["JwtOptions:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SigningKey"]))
//        };
//    });

//builder.Services.AddSwaggerGen(swagger =>
//{
//    swagger.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Microservicio Tramite",
//        Description = "Tramites Animales"
//    });

//    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header
//    });

//    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//           }, Array.Empty<string>()
//       }
//    });
//});
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AnimalDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAnimalQuery, AnimalQuery>();
builder.Services.AddScoped<IAnimalCommand, AnimalCommand>();
builder.Services.AddScoped<IAnimalServices, AnimalServices>();

builder.Services.AddScoped<IAnimalRazaQuery, AnimalRazaQuery>();
builder.Services.AddScoped<IAnimalRazaCommand,AnimalRazaCommand>();
builder.Services.AddScoped<IAnimalRazaService, AnimalRazaService>();

builder.Services.AddScoped<IAnimalTipoQuery, AnimalTipoQuery>();
builder.Services.AddScoped<IAnimalTipoCommand, AnimalTipoCommand>();
builder.Services.AddScoped<IAnimalTipoService, AnimalTipoServices>();

builder.Services.AddScoped<IFotoQuery, FotoQuery>();
builder.Services.AddScoped<IFotoCommand, FotoCommand>();
builder.Services.AddScoped<IFotoServices, FotoServices>();

builder.Services.AddScoped<IAnimalMapper, AnimalMapper>();
builder.Services.AddScoped<IAnimalTipoMapper, AnimalTipoMapper>();
builder.Services.AddScoped<IFotoMapper, FotoMapper>();
builder.Services.AddScoped<IAnimalRazaMapper,AnimalRazaMapper>();

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
