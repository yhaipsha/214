using UnityEngine;
using System.Collections;

public class LevelLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
//	public GameObject labelCaption;
	// Update is called once per frame
	void Update () {
	
	}
	void init()
	{
		 transform.FindChild("LabelCaption").GetComponent<UILabel>().text=PlayerPrefs.GetString("NowModeCaption");
	}
}
