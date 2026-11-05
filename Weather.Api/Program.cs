using Weather.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/weatherforecast", (ILogger<Program> logger) =>
    {
        return Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WeatherData.Summaries[Random.Shared.Next(WeatherData.Summaries.Length)]
            }
        ).ToArray();
    })
    .WithName("GetWeatherForecast");

app.Run();
