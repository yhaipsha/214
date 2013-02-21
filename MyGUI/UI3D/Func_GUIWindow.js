#pragma strict

static var WindowSwitch : boolean = false;  
var mySkin : GUISkin;  
var windowRect = Rect (200, 80, 240, 100);  
function OnGUI ()  
{  
   if(WindowSwitch ==  true)  
   {  
      GUI.skin = mySkin;  
        windowRect = GUI.Window (0, windowRect, WindowContain, "Test Window");  
   }  
}  
function WindowContain (windowID : int)  
{  
    if (GUI.Button (Rect (70,40,100,20), "Close Window"))  
   {  
      WindowSwitch = false;  
   }  
}  

function OnMouseEnter ()  
{  
    renderer.material.color = Color.red;  
}  

function OnMouseDown ()  
{  
   Func_GUIWindow.WindowSwitch = true;    
}  

function OnMouseExit ()  
{  
   renderer.material.color = Color.white;  
}  