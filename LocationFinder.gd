extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var locationPlugin

# Called when the node enters the scene tree for the first time.
func _ready():
	get_tree().connect("on_request_permissions_result", self, "result")
	if(OS.request_permissions()):
		result("", true)
	pass # Replace with function body.

func result(permission, granted):
	if granted:
		if Engine.has_singleton("LocationPlugin"):
			locationPlugin = Engine.get_singleton("LocationPlugin")
			locationPlugin.connect("onLocationUpdates",self, "gotLocationUpdate")
			locationPlugin.connect("onLastKnownLocation",self, "gotLastKnown")
# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
func gotLocationUpdate(locdata):
	get_tree().get_nodes_in_group("GameManager")[0].RecieveLocationData(locdata.latitude, locdata.longitude)
	pass
	
func gotLastKnown(locdata):
	get_tree().get_nodes_in_group("GameManager")[0].RecieveLocationData(locdata.latitude, locdata.longitude)
	pass
	
func getLocation():
	locationPlugin.getLastKnowLocation()
