FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ExifWeatherLens/ExifWeatherLens.csproj", "ExifWeatherLens/"]
RUN dotnet restore "ExifWeatherLens/ExifWeatherLens.csproj"
COPY . .
WORKDIR "/src/ExifWeatherLens"
RUN dotnet build "ExifWeatherLens.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExifWeatherLens.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExifWeatherLens.dll"]
