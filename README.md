# ExifWeatherLens

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

**ExifWeatherLens** is a lightweight service that extracts EXIF metadata from photos and retrieves weather information based on where and when the photo was taken. 

Ever wondered what the weather was like when a specific photo was captured? Just upload the image, and the service will read the GPS coordinates and timestamp, then fetch the historical or current weather data for that exact moment.

## Features

- **EXIF Metadata Extraction:** Automatically parses GPS coordinates (latitude/longitude) and datetime from image files.
- **Weather API Integration:** Fetches accurate weather data based on the extracted location.
- **RESTful API:** Simple and intuitive endpoints to integrate with your web or mobile applications.

## Tech Stack

- **Language:** C#
- **Framework:** .NET

### Installation & Running Locally

1. **Clone the repository:**
   ```bash
   git clone https://github.com/sozvezdiehydra/exifweatherlens.git
   cd exifweatherlens
2. **Build the project**
   ```bash
   dotnet build
3. **Run as a Console Application**
   If you are running the service as a CLI tool, you can execute it via dotnet run and pass the path to your photo as an argument:
   ```bash
   dotnet run --project ExifWeatherLens -- "/path/to/your/photo.jpg"
   ```
   for the test and posted a few photos in:
   ```bash 
   "ExifWeatherLens\ExifWeatherLens\Resources"
   ```

