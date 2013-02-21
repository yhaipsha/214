using UnityEngine;
using System.Collections;

public class BtnExit : MonoBehaviour {
	
	private GameObject obj;
	// Use this for initialization
	void Start () {
		obj = this.transform.parent.gameObject;//KeyCode.Escape;
	}
	
	void OnClick ()
	{
		Destroy(obj);

	}

}
