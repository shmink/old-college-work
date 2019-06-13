#pragma strict



function Update () 
{
}

function OnGUI()
{
	var minutes = Mathf.FloorToInt(Time.time / 60F);
	var seconds = Mathf.FloorToInt(Time.time - minutes * 60);
	
	var niceTime = ToString().Format("{0:00}:{1:00}", minutes, seconds);
	
	GUI.Label(Rect(55,60,70,25), "Time: " + niceTime);
	
	
	//var x = target.position.x;
	//var z = target.position.z;
	
	//var displayX = x.ToString();
	//var displayZ = z.ToString();
	
	//GUI.Label(Rect(70,60,70,25), "X: " + displayX);
	//GUI.Label(Rect(75,60,70,25), "Z: " + displayZ);
}


//function OnGUI()      first attempt, time needed formatting.
//{
	
	//var playerTime;
	//playerTime = Time.time;
	//var totalPlayerTime = playerTime.ToString(); 
	////GUI.Label(Rect(20,60,50,25), "Time: ");
	//GUI.Label(Rect(55,60,50,25), "Time: " + totalPlayerTime);
//}