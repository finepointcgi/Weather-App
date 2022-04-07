using Godot;
using System;

public class MainInterface : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public PackedScene WeatherDailyShort;
    [Export]
    public PackedScene HourlyForcastObject;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public async void SetMainInterface(Root root){
        
        Label tempLabel = GetNode("ScrollContainer/VBoxContainer/WeatherBox/Temp") as Label;
        tempLabel.Text = root.current.temp.ToString().Split('.')[0];
        
        Label weatherDescLabel = GetNode("ScrollContainer/VBoxContainer/WeatherBox/Weather Desc") as Label;
        weatherDescLabel.Text = root.current.weather[0].main;

         Label dayTimeLabel = GetNode("ScrollContainer/VBoxContainer/WeatherBox/DayTimeText") as Label;
        dayTimeLabel.Text = Utilities.UnixTimeStampToDateTime(root.current.sunrise).TimeOfDay.ToString();

         Label nightTimeLabel = GetNode("ScrollContainer/VBoxContainer/WeatherBox/NightTimeText") as Label;
        nightTimeLabel.Text =  Utilities.UnixTimeStampToDateTime(root.current.sunset).TimeOfDay.ToString();

        (GetNode("ScrollContainer/VBoxContainer/WeatherBox/WeatherIcon") as TextureRect).Texture = Utilities.SetTexture(root.current.weather[0].main);

        for (int i = 1; i < root.daily.Count; i++)
        {
            Daily item = root.daily[i];
            WeatherDayShort weatherDayShort = WeatherDailyShort.Instance() as WeatherDayShort;
            weatherDayShort.SetTextureAndLabelData(item);
            Node node = GetNode("ScrollContainer/VBoxContainer/DailyWeatherShortBox/HBoxContainer") as Node;
            node.AddChild(weatherDayShort);
        }

        for (int i = 0; i < 24; i++)
        {
            Hourly hourly = root.hourly[i];
            HourlyForcast hourlyForcast = HourlyForcastObject.Instance() as HourlyForcast;
            hourlyForcast.SetHourlyForcastValues(hourly);
            (GetNode("ScrollContainer/VBoxContainer") as Node).AddChild(hourlyForcast);

        }
    }

    public async void SetLocation(ReverseLookup reverseLookup){
        string location = reverseLookup.address.city == null ? reverseLookup.address.town : reverseLookup.address.city;
        (GetNode("ScrollContainer/VBoxContainer/Title/Label") as Label).Text = $"{location} {reverseLookup.address.state}";
    }
}
