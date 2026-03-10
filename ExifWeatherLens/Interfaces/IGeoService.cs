namespace ExifWeatherLens.Interfaces;

public interface IGeoService
{
    string GetCity(double latitude, double longitude);
}