using ExifWeatherLens.Models;

namespace ExifWeatherLens.Interfaces;

public interface IWeatherService
{
    Task<WeatherInfo> GetWeatherAsync(double latitude, double longitude, DateTime date);
}