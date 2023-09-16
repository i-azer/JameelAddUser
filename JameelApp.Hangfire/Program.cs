using Hangfire;
using JameelApp.Application;
using JameelApp.Application.Contracts;
using JameelApp.EntityFramework.SQLServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IJameelUserApplicationService, JameelUserApplicationService>();
builder.Services.AddDbContext<JameelDatabaseContext>(
        options => options
        .UseSqlServer(builder.Configuration
        .GetConnectionString("Default")));
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));
builder.Services.AddSignalR();

builder.Services.AddHangfireServer();

var app = builder.Build();

app.MapGet("/", () => "Hangfire Worker");
app.UseHangfireDashboard();
app.Run();
