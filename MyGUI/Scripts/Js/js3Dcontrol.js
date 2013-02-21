#pragma strict

//前进速度
var Speed = 5;

function Start()
{
	//Speed = Time.smoothDeltaTime;
}
//前进
function ForWard() 
{
	//transform.Translate(Vector3.forward * Time.deltaTime *Speed);
	transform.Translate(Vector3.up * Time.deltaTime *Speed);
}

//后退
function Back() 
{
    //transform.Translate(Vector3.forward * Time.deltaTime * -Speed);		
    transform.Translate(Vector3.up * Time.deltaTime * -Speed);		
}


//向左
function GLeft() 
{
	transform.Translate(Vector3.right * Time.deltaTime *-Speed);
}

//向右
function GRight() 
{
    transform.Translate(Vector3.right * Time.deltaTime * Speed);		
}




//传递参数

//左旋转
function leftRotate(obj)
{
	transform.Rotate(obj);	
}

//右旋转
function RightRotate(obj)
{
	transform.Rotate(obj);	
}