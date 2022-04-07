using Godot;
using System;

public class WeatherDayShort : Control
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

    public void SetTextureAndLabelData(Daily weatherData){
        (GetNode("TextureRect") as TextureRect).Texture = Utilities.SetTexture(weatherData.weather[0].main);
        (GetNode("Label") as Label).Text = weatherData.temp.day.ToString().Split('.')[0];
    }
}
