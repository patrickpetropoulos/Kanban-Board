

using Kanban.Server.Application.Projects;
using Kanban.Server.Domain.Projects;
using Kanban.Server.Infrastructure.Projects;
using Microsoft.Azure.Cosmos;

public class Program
{
  public static void Main(string[] args)
  {

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApplicationInsightsTelemetry();

    builder.Services.AddSingleton( x => new CosmosClient( builder.Configuration["CosmosDb:Account"], builder.Configuration["CosmosDb:Key"] ) );
    builder.Services.AddSingleton<ICosmosProjectService, CosmosProjectService>();



    var app = builder.Build();

// Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
      app.UseSwagger();
      app.UseSwaggerUI();
    //}


    app.UseHttpsRedirection();


    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.MapFallbackToFile("index.html");

    var summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    app.MapGet("/weatherforecast", async ( ILogger<Program> logger, ICosmosProjectService cosmosProjectService ) =>
      {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
              DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
              Random.Shared.Next(-20, 55),
              summaries[Random.Shared.Next(summaries.Length)]
            ))
          .ToArray();
        logger.LogInformation( "Logging from the minimal API endpoint" );
        logger.LogError( $"Logging from weather with chance of {forecast[0].Summary}" );

        var project = new Project(Guid.NewGuid(), new ProjectName( forecast[0].Summary ) );
        var cosmosResult = await cosmosProjectService.UpsertProjectAsync( project );
        if (cosmosResult.IsSuccess)
        {
          logger.LogInformation( $"Success with code  {cosmosResult.Value.HttpStatusCode} and charge {cosmosResult.Value.ResultCharge}" );
        }
        else
        {
          logger.LogError( $"Error: {cosmosResult.Error.Name}" );
        }


        return forecast;
      })
      .WithName("GetWeatherForecast")
      .WithOpenApi();



    app.Run();
  }

}


public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}