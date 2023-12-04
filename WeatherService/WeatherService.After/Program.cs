using WeatherService.After.Domain;
using WeatherService.After.Shared;
using WeatherService.Before.Application;

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
        var result = await weatherService.GetWeatherData(city);

        return result.ToHttpResult();
    })
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();