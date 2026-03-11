using System.Globalization;
using System.Text.Json;
using ExifWeatherLens.Interfaces;
using ExifWeatherLens.Models;

namespace ExifWeatherLens.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _client;

    public WeatherService(HttpClient httpClient)
    {
        _client = httpClient;
    }
    
    public async Task<WeatherInfo> GetWeatherAsync(double latitude, double longitude, DateTime date)
    {
        string dateToString = date.ToString("yyyy-MM-dd");
        string lat = latitude.ToString(CultureInfo.InvariantCulture);
        string lon = longitude.ToString(CultureInfo.InvariantCulture);
        
        string url = $"https://archive-api.open-meteo.com/v1/archive?latitude={lat}&longitude={lon}&start_date={dateToString}&end_date={dateToString}&hourly=temperature_2m,precipitation&timezone=auto";
        
        var response = await _client.GetStringAsync(url);
        var data = JsonSerializer.Deserialize<JsonElement>(response);

        int hour = date.Hour;
        double temp = data.GetProperty("hourly").GetProperty("temperature_2m")[hour].GetDouble();
        double precip = data.GetProperty("hourly").GetProperty("precipitation")[hour].GetDouble();
        
        return new WeatherInfo
        {
            Temperature = temp,
            Precipitation = precip,
            WeatherDescription = precip > 0 ? "Rainy" : "Clear"
        };
    }
}