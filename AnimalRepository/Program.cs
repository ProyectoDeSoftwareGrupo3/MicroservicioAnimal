using Application.Interfaces.IAnimalRaza;
using Application.UseCases;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<AnimalDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IAnimalRazaQuery, AnimalRazaQuery>();
builder.Services.AddScoped<IAnimalRazaCommand,AnimalRazaCommand>();
builder.Services.AddScoped<IAnimalRazaService, AnimalRazaService>();

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
