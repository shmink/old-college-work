
function OnGUI()
{
	if(GUI.Button(Rect((Screen.width/2 - 75),350,200,75),"Play Game"))
		Application.LoadLevel(1);
	
	if(GUI.Button(Rect((Screen.width/2 - 75),450,200,75),"Exit Game"))
		Application.Quit();
}