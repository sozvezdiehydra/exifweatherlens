namespace ExifWeatherLens.Models;

public class PhotoMetadata
{
    public DateTime? DateTime { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? CameraModel { get; set; }
}