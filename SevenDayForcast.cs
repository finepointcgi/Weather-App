using Godot;
using System;

public class SevenDayForcast : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public PackedScene SevenDayForcastElementObject;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public async void SetSevenDayForcast(Root root){
        for (int i = 0; i < root.daily.Count; i++)
        {
            Daily daily = root.daily[i];
            SevenDayForcastElement sevenDayForcastElement = SevenDayForcastElementObject.Instance() as SevenDayForcastElement;
            (GetNode("ScrollContainer/VBoxContainer") as Node).AddChild(sevenDayForcastElement);
            sevenDayForcastElement.SetSevenDayForcastLabels(daily);
        }
    }

}
