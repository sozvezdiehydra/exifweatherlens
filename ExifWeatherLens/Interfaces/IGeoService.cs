using ExifWeatherLens.Models;

namespace ExifWeatherLens.Interfaces;

public interface IGeoService
{
    GeoInfo GetLocation(double latitude, double longitude);
}