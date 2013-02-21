#pragma strict

//旋转移动速度
var Speed = 5;

//控制对象
var Control:js3Dcontrol;

function Update()
{
  //得到控制对象
  Control = GetComponent("js3Dcontrol"); 
  
  //判断按键 
    
  if(Input.GetKey(KeyCode.W))
  {
  	    //前进
   		Control.ForWard();
   		
  }else if(Input.GetKey(KeyCode.S))	
  {
		//后退
  		Control.Back();
  }
  
    if(Input.GetKey(KeyCode.A))
  {
  	    //前左
   		Control.GLeft();
   		
  }else if(Input.GetKey(KeyCode.D))	
  {
		//后右
  		Control.GRight();
  }
  
  
  
  if(Input.GetKeyDown(KeyCode.Q))
  {
  	//左旋转() 绕Y轴旋转 	
    //Control.leftRotate(Vector3.up *Time.deltaTime * -Speed);
    //绕Z轴旋转
    //Control.leftRotate(Vector3.forward *Time.deltaTime * -Speed);
	transform.Rotate(0,0,90);
  }else if(Input.GetKeyDown(KeyCode.E))
  {
    //右旋转
  	Control.RightRotate(Vector3.forward *Time.deltaTime * Speed);
	transform.Rotate(0,0,-90);
  }
   
}