using Hangfire;
using JameelApp.Application;
using JameelApp.Application.Contracts;
using JameelApp.Application.Contracts.JameelUserDto;
using JameelApp.EntityFramework.SQLServer;
using JameelApp.Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});
builder.Services.AddScoped<IJameelUserApplicationService, JameelUserApplicationService>();
builder.Services.AddScoped<IJameelUserOffLoader, JameelUserOffLoader>();

var app = builder.Build();
app.UseCors("CORSPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/users/add", async (JameelUserRequestDto jameelUserRequestDto,
    IJameelUserOffLoader appOffloader) =>
{
    await appOffloader.InsertIntoDatabase(jameelUserRequestDto);
    return Results.Json(jameelUserRequestDto);
});

app.Run();
