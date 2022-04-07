using Godot;
using System;

public class HourlyForcast : Control
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

    public void SetHourlyForcastValues(Hourly hourly){
        (GetNode("HourTime") as Label).Text = Utilities.UnixTimeStampToDateTime(hourly.dt).TimeOfDay.ToString();
        (GetNode("TempValue") as Label).Text = hourly.temp.ToString().Split(".")[0];
    }
}
