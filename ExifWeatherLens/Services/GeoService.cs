using ExifWeatherLens.Interfaces;
using ExifWeatherLens.Models;
using ReverseGeocoding;

namespace ExifWeatherLens.Services;

public class GeoService : IGeoService
{
    private readonly ReverseGeocoder? _reverseGeocoder;
    private readonly Dictionary<string, string> _regionNames = new();

    public GeoService()
    {
        var filePath = @"E:\petproject\ExifWeatherLens\ExifWeatherLens\Data\cities1000.txt";
        var asciiCountryCodes = @"E:\petproject\ExifWeatherLens\ExifWeatherLens\Data\admin1CodesASCII.txt";
        
        _reverseGeocoder = new ReverseGeocoder(filePath);

        /*if (File.Exists(asciiCountryCodes))
        {
            foreach (var line in File.ReadAllLines(asciiCountryCodes))
            {
                var parts = line.Split('\t');
                if (parts.Length >= 2)
                {
                    string key = parts[0];
                    string name = parts[1];

                    _regionNames[key] = name;
                }
            }
        }*/
        
    }
    
    public GeoInfo GetLocation(double latitude, double longitude)
    {
        var result = _reverseGeocoder?.GetNearestPlace(latitude, longitude);

        if (result == null)
        {
            return new GeoInfo();
        }

        // string regionKey = $"{result.CountryCode}.{result.Admin1Code}";

        // _regionNames.TryGetValue(regionKey, out var regionName);
        
        return new GeoInfo()
        {
            City = result.Name,
            Country = result.CountryCode,
            Region = result.Admin2Code
        };
    }
}