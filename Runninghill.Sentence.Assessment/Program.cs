using Runninghill.Sentence.Assessment.Infrastructure;
using Runninghill.Sentence.Assessment.Application;
using Serilog;
using Runninghill.Sentence.Assessment.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddLogging(loggerConfig =>
{
    loggerConfig.AddConsole();
});
var app = builder.Build();

Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.Console().CreateLogger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.Services.InitialiseDatabaseAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.ApplyDatabaseMigrations(builder.Configuration);
app.Run();

public partial class Program { }
