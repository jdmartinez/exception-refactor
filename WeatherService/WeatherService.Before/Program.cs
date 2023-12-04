using WeatherService.Before.Application;
using WeatherService.Before.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, OpenWeatherMapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weather",
    async (IWeatherService weatherService, string city) =>
    {
        try
        {
            return Results.Ok(await weatherService.GetWeatherData(city));
        }
        catch (CityNotFoundException notFoundEx)
        {
            return Results.NotFound(notFoundEx.Message);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    })
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();