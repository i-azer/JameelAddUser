using Hangfire;
using JameelApp.Application;
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
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));
builder.Services.AddHangfireServer();
builder.Services.AddTransient<IJameelUserApplicationService, JameelUserApplicationService>();
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
