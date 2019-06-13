#pragma strict

function Start() {}

//inspector variables
 
var speed : float=5;
var turnSpeed : float=180; 
 
function Update()
{
    var turn = Input.GetAxis("Horizontal");
    var forward = Input.GetAxis("Vertical");
 
    if (forward!=0)
    {
        var moveDist = forward * speed * Time.deltaTime;

        var turnAngle = turn * turnSpeed * Time.deltaTime * forward;
 
        transform.rotation.eulerAngles.y += turnAngle;

        transform.Translate(Vector3.forward * moveDist);
    }
    
    if(Input.GetKey(KeyCode.Escape))
    	Application.Quit();
 
}

//function Update () {



//var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
//var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
//transform.Translate(x, 0, z);
//}