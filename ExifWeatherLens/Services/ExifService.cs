using ExifWeatherLens.Interfaces;
using ExifWeatherLens.Models;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ExifWeatherLens.Services;

public class ExifService : IExifService
{
    public PhotoMetadata GetMetadata(string filePath)
    {
        var directories = ImageMetadataReader.ReadMetadata(filePath);
        var exif = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
        var gps = directories.OfType<GpsDirectory>().FirstOrDefault();
        
        double? lat = null;
        double? lng = null;
        DateTime? dt = null;
        
        if (gps != null && gps.TryGetGeoLocation(out var location))
        {
            lat = location.Latitude;
            lng = location.Longitude;
        }
        
        if (exif != null && exif.TryGetDateTime(ExifDirectoryBase.TagDateTimeOriginal, out var dateTime))
        {
            dt = dateTime;
        }

        return new PhotoMetadata
        {
            DateTime = dt,
            Latitude = lat,
            Longitude = lng,
            CameraModel = directories.OfType<ExifIfd0Directory>().FirstOrDefault()?.GetString(ExifDirectoryBase.TagModel)
        };
    }
}