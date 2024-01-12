using NuvoControl.Common;
using NuvoControl.Server.WebConsole;


// Load command line argumnets
Options _options = new Options();
CommandLine.Parser.Default.ParseArguments(args, _options);

// Set global verbose mode
LogHelper.SetOptions(_options);
LogHelper.LogAppStart("Server Console");
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
