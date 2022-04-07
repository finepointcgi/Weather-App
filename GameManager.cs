using Godot;
using Newtonsoft.Json;
using System;
using System.Text;

public class GameManager : Control
{
    public string ApiKey = "f6d581839af81b536cd821a7e0d6de22";
    public string Lat;
    public string Lon;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private Vector2 swipeStart;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        (GetNode("LocationFinder") as Node).Call("getLocation");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _on_HTTPRequest_request_completed(int result, int response_code, string[] headers, byte[] body){
        string s = Encoding.UTF8.GetString(body);
        Root root = JsonConvert.DeserializeObject<Root>(s);
        (GetNode("MainInterface") as MainInterface).SetMainInterface(root);
        (GetNode("7DayForcast") as SevenDayForcast).SetSevenDayForcast(root);
    }

    public void _on_NameResolution_request_completed(int result, int response_code, string[] headers, byte[] body){
        string data = Encoding.UTF8.GetString(body);
        ReverseLookup reverseLookup = JsonConvert.DeserializeObject<ReverseLookup>(data);
         (GetNode("MainInterface") as MainInterface).SetLocation(reverseLookup);
    }

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventScreenTouch){
            InputEventScreenTouch touch = @event as InputEventScreenTouch;
            if(touch.Pressed){
                swipeStart = touch.Position;
            }else{
                CalculateSwipe(touch.Position);
            }
        }
    }

    public void CalculateSwipe(Vector2 swipeEnd){
        if(swipeStart == new Vector2(0,0)){
            return;
        }

        var swipe = swipeEnd - swipeStart;
        if(Mathf.Abs(swipe.x) > 100){
            if(swipe.x > 0){
                GD.Print("SwipeRight");
                swipeRight();
            }else{
                GD.Print("SwipeLeft");
                swipeLeft();
                swipeStart = new Vector2();
            }
        }
    }

    private void swipeRight(){
        Tween tween = GetNode("Tween") as Tween;
        SevenDayForcast sevenDayForcast = GetNode("7DayForcast") as SevenDayForcast;
        tween.InterpolateProperty(sevenDayForcast,"rect_position",sevenDayForcast.RectPosition,new Vector2(600,0), .1f);
        tween.Start();
    }

    private void swipeLeft(){
        Tween tween = GetNode("Tween") as Tween;
        SevenDayForcast sevenDayForcast = GetNode("7DayForcast") as SevenDayForcast;
        tween.InterpolateProperty(sevenDayForcast,"rect_position",sevenDayForcast.RectPosition,new Vector2(0,0), .1f);
        tween.Start();
    }

    private void _on_Seven_Day_Forcast_button_down(){
        swipeLeft();
    }

    private void _on_Main_Page_button_down(){
        swipeRight();
    }

    public void RecieveLocationData(object lat, object lon){
        Lat = lat.ToString();
        Lon = lon.ToString();
        HTTPRequest request = GetNode("HTTPRequest") as HTTPRequest;
        request.Request("https://api.openweathermap.org/data/2.5/onecall?lat=" + Lat + "&lon=" + Lon + "&units=imperial&exclude={part}&appid=" + ApiKey);
        HTTPRequest nameResolutionRequest = GetNode("NameResolution") as HTTPRequest;
        nameResolutionRequest.Request("https://nominatim.openstreetmap.org/reverse?lat=" + Lat + "&lon=" + Lon + "&format=json");
    }
}
