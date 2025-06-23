using Microsoft.EntityFrameworkCore;
using PT_LiderIT_Alejandro.Data;
using PT_LiderIT_Alejandro.Repositories;
using PT_LiderIT_Alejandro.Repositories.Interfaces;
using PT_LiderIT_Alejandro.Services;
using PT_LiderIT_Alejandro.Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITareaRepository, TareaRepository>();
builder.Services.AddScoped<ITareaService, TareaService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TareasDb"));

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
 