using System;
using ExifWeatherLens.Interfaces;
using ExifWeatherLens.Services;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = @"E:\petproject\ExifWeatherLens\ExifWeatherLens\Resources\canontest.jpg";

        IExifService exifService = new ExifService();
        IWeatherService weatherService = new WeatherService(new HttpClient());

        var metaData = exifService.GetMetadata(filePath);
        
        Console.WriteLine($"Photo Info");
        Console.WriteLine($"File: {filePath}");
        Console.WriteLine($"Data: {metaData.DateTime?.ToString() ?? "Idk"}");
        Console.WriteLine($"Camera: {metaData.CameraModel ?? "Unknown"}");
        
        if (metaData.Latitude.HasValue && metaData.Longitude.HasValue)
        {
            Console.WriteLine($"Coordinates: {metaData.Latitude.Value}, {metaData.Longitude.Value}");
            
            try 
            {
                var weather = await weatherService.GetWeatherAsync(
                    metaData.Latitude.Value, 
                    metaData.Longitude.Value,
                    metaData.DateTime ?? DateTime.Now); 

                Console.WriteLine($"Weather lens");
                Console.WriteLine($"Temperature: {weather.Temperature}°C");
                Console.WriteLine($"Precipitation: {weather.Precipitation} мм");
                Console.WriteLine($"Description: {weather.WeatherDescription}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get data: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Gps data not found");
        }
    }
}