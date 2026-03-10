using ExifWeatherLens.Models;

namespace ExifWeatherLens.Interfaces;

public interface IExifService
{
    PhotoMetadata GetMetadata(string filePath);
}