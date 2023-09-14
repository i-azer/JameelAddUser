using JameelApp.Application.Contracts;
using JameelApp.Application.Contracts.JameelUserDto;
using JameelApp.EntityFramework.SQLServer;
using JameelApp.Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JameelDatabaseContext>(
        options => options
        .UseSqlServer(builder.Configuration
        .GetConnectionString("Default")));
builder.Services.AddTransient<IJameelUserOffLoader, JameelUserOffLoader>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/users/add", async (JameelUserRequestDto jameelUserRequestDto, IJameelUserOffLoader appOffloader) =>
{
    await appOffloader.InsertIntoDatabase(jameelUserRequestDto);
    return Results.Ok();
});

app.Run();
