using UnityEngine;
using System.Collections;

public class SelectedLevel : MonoBehaviour
{
	
	//初始化游戏页面 
	
	
	public GameObject exampleFruit;
	void OnClick ()
	{
		
		UILabel lblLevelName = GetComponentInChildren<UILabel> ();
		PlayerPrefs.SetInt ("NowPlay", int.Parse (lblLevelName.text.Trim ()));

	}
}
