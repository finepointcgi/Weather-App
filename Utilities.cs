using System;
using Godot;
public static class Utilities
{
    public static Texture Sunny = ResourceLoader.Load("res://WeatherIcons/sun.png") as Texture;
    public static Texture Moon = ResourceLoader.Load("res://WeatherIcons/Moon.png") as Texture;
    public static Texture PartlyCloudy = ResourceLoader.Load("res://WeatherIcons/PartlyCloudy.png") as Texture;
    public static Texture Rain = ResourceLoader.Load("res://WeatherIcons/Rain.png") as Texture;
    public static Texture PartlyCloudyMoon = ResourceLoader.Load("res://WeatherIcons/PartlyCloudyMoon.png") as Texture;
    public static Texture SemiCloudy = ResourceLoader.Load("res://WeatherIcons/semiCloudy.png") as Texture;
    public static Texture SmallRain = ResourceLoader.Load("res://WeatherIcons/SmallRain.png") as Texture;
    public static Texture ThunderStorm = ResourceLoader.Load("res://WeatherIcons/ThunderStorm.png") as Texture;
    public static Texture Cloudy = ResourceLoader.Load("res://WeatherIcons/Cloudy2.png") as Texture;
    public static Texture CloudyRain = ResourceLoader.Load("res://WeatherIcons/CloudyRain.png") as Texture;
    public static Texture CloudyThunderstorm = ResourceLoader.Load("res://WeatherIcons/CloudyThunderstorm.png") as Texture;
    public static Texture HeavyRainThunderstorm = ResourceLoader.Load("res://WeatherIcons/HeavyRainThunderstorm.png") as Texture;

    public static DateTime UnixTimeStampToDateTime(int timeStamp)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(timeStamp).ToLocalTime();
        return dateTime;
    }

    public static Texture SetTexture(string weather)
    {
        GD.Print(weather);
        switch (weather)
        {
            case "Thunderstorm":
                return ThunderStorm;
            case "Drizzle":
                return SmallRain;
            case "Rain":
                return Rain;
            case "Snow":
                return Rain;
            case "Clear":
                return Sunny;
            case "Clouds":
                return SemiCloudy;
            default:
                return Sunny;
        }
    }
}