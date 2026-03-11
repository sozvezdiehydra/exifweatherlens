using System;
using ExifWeatherLens.Interfaces;
using ExifWeatherLens.Services;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = @"E:\petproject\ExifWeatherLens\ExifWeatherLens\Resources\testgps.jpg";

        IExifService exifService = new ExifService();
        IGeoService geoService = new GeoService();
        IWeatherService weatherService = new WeatherService(new HttpClient());

        var metaData = exifService.GetMetadata(filePath);

        
        Console.WriteLine($"Photo Info");
        Console.WriteLine($"File: {filePath}");
        Console.WriteLine($"Data: {metaData.DateTime?.ToString() ?? "Idk"}");
        Console.WriteLine($"Camera: {metaData.CameraModel ?? "Unknown"}");
        
        if (metaData.Latitude.HasValue && metaData.Longitude.HasValue)
        {
            var location = geoService.GetLocation(
                metaData.Latitude.Value,
                metaData.Longitude.Value);
            
            Console.WriteLine($"Coordinates: {metaData.Latitude.Value}, {metaData.Longitude.Value}");
            Console.WriteLine($"Country: {location.Country}");
            Console.WriteLine($"Region: {location.Region}");
            Console.WriteLine($"City: {location.City}");
            
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