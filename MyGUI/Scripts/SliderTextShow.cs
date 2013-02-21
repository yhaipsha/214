using UnityEngine;
using System.Collections;
using Sheep.para;

[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
public class SliderTextShow : MonoBehaviour
{
	string _FileLocation, _FileName;

//   UserData myData; 
	SysData sheepData;
	string _PlayerName;
	string _data;
	
	UILabel mWidget;

	void OnSliderChange (float val)
	{
		if (mWidget == null){
			mWidget = GetComponent<UILabel> ();
			mWidget = GameObject.Find("ShowLabel").GetComponent<UILabel>();	
		}
		mWidget.text = "Value:" + (val).ToString ("F2");
	}

	void Start ()
	{
		sheepData = new SysData ();
		_FileLocation = Application.dataPath; 
		_FileName = "MyGUI/gameData/sheep.xml";//"SaveData.xml"; 
		
		
		_data = GameLoad.LoadXML (_FileLocation + "\\" + _FileName);
		if (_data.ToString () != "") { 
			// notice how I use a reference to type (UserData) here, you need this 
			// so that the returned object is converted into the correct type 
			sheepData = (SysData)GameLoad.DeserializeObject (sheepData, _data); 
			UISlider slider = GetComponent<UISlider> ();
			if (slider != null) {
				slider.sliderValue = sheepData.Volume;
				slider.onValueChange += OnSliderChange;
//				slider.eventReceiver = this.OnSliderChange;
			}
			
		}
	}
}
