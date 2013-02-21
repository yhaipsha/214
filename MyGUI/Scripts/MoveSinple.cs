using UnityEngine;
using System.Collections;

public class MoveSinple : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		WWW www = new WWW("file://" + Application.dataPath + "/../SystemData.assetbundle");
		yield return www;
		SystemData sd = www.assetBundle.mainAsset as SystemData;print(sd.content[1]);
		
	}
	
	// Update is called once per frame
	void Update () {
		//pressKeyboard();
		
		// transform.Translate(Input.GetAxis("Horizontal"), 0.01, Input.GetAxis("Vertical")); 
	}
	void pressKeyboard()
	{
			if (Input.GetKey(KeyCode.J)) {
				transform.position += Vector3.down * Time.smoothDeltaTime;
			}
		
		
	}
}
