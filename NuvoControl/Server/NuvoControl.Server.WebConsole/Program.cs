using Common.Logging;
using NuvoControl.Common;
using NuvoControl.Common.Configuration;
using NuvoControl.Server.FunctionServer;
using NuvoControl.Server.OscServer;
using NuvoControl.Server.ProtocolDriver;
using NuvoControl.Server.ProtocolDriver.Interface;
using NuvoControl.Server.WebConsole;
using NuvoControl.Server.ZoneServer;
using System.DirectoryServices;
using LogLevel = Common.Logging.LogLevel;


// Load command line argumnets
Options _options = new Options();
CommandLine.Parser.Default.ParseArguments(args, _options);

// Set global verbose mode
LogHelper.SetOptions(_options);
LogHelper.LogAppStart("Server Web Console");
LogHelper.LogArgs(args);
if (_options.Help)
{
    Console.WriteLine(_options.GetUsage());
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

NuvoControlController _nuvocontroller = new NuvoControlController();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Not executed ....
_nuvocontroller.UnloadAllServices();
