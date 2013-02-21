using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using MiniJSON;
using LitJson;
public class MiniJsonDemo : MonoBehaviour
{

//	var url = "file://D:/workspace/Unity3D/Second/Assets/MyGUI/GameData/json.txt";//"http://search.twitter.com/search.json?q=Unity3d"
	void Start ()
	{

		StartCoroutine ("GetTwitterUpdate");     

	}

	IEnumerator GetTwitterUpdate ()
	{

		WWW www = new WWW ("file://D:/workspace/Unity3D/Second/Assets/MyGUI/GameData/json2.json");
		float elapsedTime = 0.0f;
		while (!www.isDone) {

			elapsedTime += Time.deltaTime;
			if (elapsedTime >= 10.0f)
				break;
			yield return null;  

		}
		
		if (!www.isDone || !string.IsNullOrEmpty (www.error)) {

			Debug.LogError (string.Format ("Fail Whale!\n{0}", www.error));
			yield break;
		}
		
		string response = www.text;
		Debug.Log (elapsedTime + " : " + response);    

//		string s = '{"name":"jtianling", "phone" : ["135xxx", "186xxx"]}';
//		LitJson.JsonData js = LitJson.JsonMapper.ToObject(response);		
//		Debug.Log("??"+js.Count);
		 
//		if (json['phone'].IsArray) {
//		  for (var json_data : LitJson.JsonData in json['phone']) {
//		    print(json_data);
//		  }
//		}
			

		
			IDictionary search = (IDictionary)Json.Deserialize(response);
//			Json.Parser(response);
//		string name =	typeof( Json.Deserialize(response)).FullName;
		
		Debug.Log("??"+Json.Deserialize(response)+">");
//		try {} catch (Exception ex) {
//			Debug.Log(ex.Message);
//		}
		
//    
//
//		IList tweets = (IList)search ["province"];//results
//
//    
//		Debug.Log("??"+ tweets[0].ToString());
//		foreach (IDictionary tweet in tweets) {
//
//			Debug.Log (string.Format ("tweet: {0} : {1}", tweet ["from_user"], tweet ["text"]));
//
//		}

	}   
}
