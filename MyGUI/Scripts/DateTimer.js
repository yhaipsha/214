#pragma strict

function Start () {
	 // Start a download of the given URL
    var www : WWW = new WWW ("http://images.earthcam.com/ec_metros/ourcams/fridays.jpg");

    // Wait for download to complete
    yield www;
    Debug.Log(www.text+"??");
    // assign texture
//    renderer.material.mainTexture = www.texture;
    

}

function Update () {

}

var gSkin:GUISkin;
var str="";
var Months:String[]=["一月","二月","三月","四月","五月","六月","七月","八月","九月","十月","十一月","十二月"];
var Days:String[]= ["１","２","３","４","５","６","７","８","９","10","11","12","13","14","15","16","17","18","19","20",
"21","22","23","24","25","26","27","28","29","30","31"];
var dNow:System.DateTime;
var i=0;
function OnGUI()
{
	if(gSkin)
		GUI.skin=gSkin;
	        GUILayout.Box("本地日期时间："+System.DateTime.Now);//本地时间，12小时制的
	        GUILayout.Box("军事日期时间："+System.DateTime.Now.ToString("yyyyMMddHHmmss"));
	        GUILayout.Box("UTC日期时间："+System.DateTime.UtcNow);//UTC时间
	GUILayout.SelectionGrid(System.DateTime.Now.Month-1,Months,3);
	        GUILayout.SelectionGrid(System.DateTime.Now.Day-1,Days,10);
	        GUILayout.Box(str+dNow.Now.Year+"年"+dNow.Now.Month+"月"+dNow.Now.Day+" 日"+"        "+dNow.Now.Hour+"时"+dNow.Now.Minute+"分"+dNow.Now.Second+"秒");
} 