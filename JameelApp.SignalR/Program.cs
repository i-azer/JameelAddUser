using JameelApp.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();





var app = builder.Build();

app.MapGet("/", () => "Hello World!");



app.MapHub<JameelUserHubBroadcaster>("jameel-broadcasting");
app.Run();
