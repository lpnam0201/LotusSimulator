using LotusSimulator;
using LotusSimulator.Core.DependencyInjection;
using LotusSimulator.DependencyInjection;
using LotusSimulator.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddGameServices();
builder.Services.AddCardLogic();

builder.Services.AddSignalR(o =>
{
    o.EnableDetailedErrors = true;
    o.KeepAliveInterval = new TimeSpan(0, 30, 0);
    o.ClientTimeoutInterval = new TimeSpan(0, 5, 0);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<GameHub>("/gameHub");

app.Run();


