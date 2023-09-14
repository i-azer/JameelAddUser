using Hangfire;
using JameelApp.Application;
using JameelApp.Application.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IJameelUserApplicationService, JameelUserApplicationService>();
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
