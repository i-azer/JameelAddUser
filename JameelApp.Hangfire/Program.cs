using Hangfire;
using JameelApp.EntityFramework.SQLServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
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

var app = builder.Build();

app.MapGet("/", () => "Hangfire Worker");
app.UseHangfireDashboard();
app.Run();
