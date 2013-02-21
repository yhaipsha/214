using UnityEngine;
using System.Collections;

public class NowMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public GameObject levelOffsetGo;
	void OnClick()
	{
		int maxItem=0;
		int pages=1;
		string Caption=string.Empty; 
		
		switch (transform.name) {
		case "BtnTop":
			Caption="Normal Mode";//"标准模式-看3秒，找出指定水果，限错3次";
			maxItem=50;
			pages=3;
			PlayerPrefs.SetInt("NowMode",1);
			break;

		case "BtnMiddle":
			maxItem=50;
			pages=3;
			Caption="Classic Mode";//"经典模式-看5秒找相同水果，限错N次";
			PlayerPrefs.SetInt("NowMode",2);
						break;
		case "BtnBotton":
			maxItem=20;
			pages=1;
			Caption="Challenge Mode";//"挑战模式-限时找相同水果，不限错次数";
			PlayerPrefs.SetInt("NowMode",3);			
			break;
		}
		PlayerPrefs.SetString("NowModeCaption",Caption);
		
		UIItemCard card = levelOffsetGo.GetComponent<UIItemCard>();
		UIPanel panel = card.transform.parent.GetComponent<UIPanel>();
		 
		Vector4 v4 = Vector4.zero;// panel.clipRange;
		v4.x=13.8f;
		v4.y=panel.clipRange.y;
		v4.z=panel.clipRange.z;
		v4.w=panel.clipRange.w;
		
		panel.clipRange = v4;
		
		card.transform.parent.position = new Vector3(0f,0f,0f);
		card.transform.localPosition=new Vector3(-311f,225f,-1f);
		card.maxItemCount=maxItem;
		card.rows=4;card.columns=5;
		card.pages=pages;
		card.initLevel();
	}
	
	
	void WriteMode()
	{
		
		
	}
}
