using JameelApp.Application;
using JameelApp.Application.Contracts;
using JameelApp.EntityFramework.SQLServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddDbContext<JameelDatabaseContext>(
        options => options
        .UseSqlServer(builder.Configuration
        .GetConnectionString("Default")));
builder.Services.AddScoped<IJameelUserApplicationService, JameelUserApplicationService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});

var app = builder.Build();
app.UseCors("CORSPolicy");
app.MapGet("/", () => "Broadcasting ...");



app.MapHub<JameelUserHubBroadcaster>(nameof(IJameelUserHubBroadcaster.JameelUserHubBroadcaster));
app.Run();
