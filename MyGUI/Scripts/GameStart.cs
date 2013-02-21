using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using YeeTong.com;


public class GameStart : MonoBehaviour {
	
	int ckValue=-1;
	void OnClick ()
    {
		Object[] objs = FindObjectsOfType(typeof(UICheckbox));
		foreach (Object obj in objs) {
			UICheckbox health = (UICheckbox)obj;		
			if(health.isChecked){
				
				CheckBoxStatus status = (CheckBoxStatus)System.Enum.Parse(typeof(CheckBoxStatus), health.name);
				
				Debug.Log("?"+ (int)status+"|"+health.name);	
				ckValue = (int)status;
			}				
					
		}
		if(ckValue == -1){
			Debug.Log("please ,selected checkbox!");
			return;
		}
		
		PlayerPrefs.SetInt("difficulty",ckValue);
		PlayerPrefs.SetInt("played",1);
        
		//SecurityCamera.ChangeCamera("MainCamera");
		//DontDestroyOnLoad();
		//Destroy(GameObject.Find("Texture"));
		//Application.LoadLevelAdditive("Demo1");
		Application.LoadLevel("Demo");
				
    }
	
	
	
}
