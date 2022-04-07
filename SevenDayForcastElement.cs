using Godot;
using System;

public class SevenDayForcastElement : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public async void SetSevenDayForcastLabels(Daily daily){
        (GetNode("Date") as Label).Text = Utilities.UnixTimeStampToDateTime(daily.dt).DayOfWeek.ToString();
        (GetNode("Day/DayTempValue") as Label).Text = daily.temp.day.ToString().Split(".")[0];
        (GetNode("Night/NightTempValue") as Label).Text = daily.temp.night.ToString().Split(".")[0];
        (GetNode("TextureRect") as TextureRect).Texture = Utilities.SetTexture(daily.weather[0].main);
    }

}
