using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text;
using Sheep.para;

public class PopupListXML : MonoBehaviour
{
	public GameObject _Player;
	string _FileLocation, _FileName;

//   UserData myData; 
	SysData sheepData;
	string _PlayerName;
	string _data;

	void Start ()
	{
		sheepData = new SysData ();
		_FileLocation = Application.dataPath; 
		_FileName = "MyGUI/gameData/sheep.xml";//"SaveData.xml"; 
		
		
		_data = GameLoad.LoadXML (_FileLocation + "\\" + _FileName);
		if (_data.ToString () != "") { 
			
			sheepData = (SysData)GameLoad.DeserializeObject (sheepData, _data); 
			// set the players position to the data we loaded 
//			VPosition = new Vector3 (sheepData._iUser.x, sheepData._iUser.y, sheepData._iUser.z);              
//			_Player.transform.position = VPosition; 
			if (_Player != null) {
				UIPopupList list = NGUITools.FindInParents<UIPopupList> (_Player);
				for (int i=0; i<sheepData.ColorList.Count; i++) {
					if (i == 2)
						list.selection = sheepData.ColorList [i].ToString ();
					list.items.Add (sheepData.ColorList [i].ToString ());
					
				}
			}

		} 
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	
	
}
