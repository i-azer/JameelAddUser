using JameelApp.Application;
using JameelApp.Application.Contracts;
using JameelApp.Application.Contracts.JameelUserDto;
using JameelApp.EntityFramework.SQLServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JameelDatabaseContext>(
        options => options
        .UseSqlServer(builder.Configuration
        .GetConnectionString("Default")));
builder.Services.AddTransient<IJameelUserApplicationService,JameelUserApplicationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/users/add", async (JameelUserRequestDto jameelUserRequestDto, IJameelUserApplicationService appService) =>
{
    var newUserToBeAdded = await appService.Add(jameelUserRequestDto)
    .ConfigureAwait(false);

    return Results.Json(newUserToBeAdded);
});

app.Run();
