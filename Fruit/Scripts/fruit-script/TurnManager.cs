using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
	
	private bool isBegin = false;
	int clickCount = 0;
	Quaternion qua;
	Quaternion quaBg;
	
	public bool autoReverse = false;
	UISprite sprite;
	UISprite spriteBg;
	bool beginTurn=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("cardReady") == 7 && beginTurn == true) {
						qua = Quaternion.Euler (new Vector3 (0f, 180f, 0f));	
			quaBg = Quaternion.Euler (Vector3.zero);
			
			StartCoroutine (show ());
			//PlayerPrefs.SetInt("cardReady",2);
		}
		
		
//		if (isBegin) {
//	
//				spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime * 3);
//				sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime * 3);
//	
//				float vEuler = Mathf.Round (spriteBg.transform.rotation.eulerAngles.y);
//				//反面
//				IsNotCorrect (vEuler);
//				//正面
//				IsCorrect (vEuler);
//	
//			}
	}
	
	
	IEnumerator show ()
	{				
		sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua * sprite.transform.localRotation, Time.deltaTime);     		
		spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg * spriteBg.transform.localRotation, Time.deltaTime);   
		
		print ("cardReady="+PlayerPrefs.GetInt("cardReady"));
		
		if( PlayerPrefs.GetInt ("cardReady") == 1)
		{
			bool correct = IsCorrect2 (Mathf.Round (sprite.transform.rotation.eulerAngles.y));
			if (correct) {				
				print ("in the correct =if");
//				yield return null;  
				yield return  new WaitForSeconds(45f);
				PlayerPrefs.SetInt ("cardReady", 2);
			}			
		}else if(PlayerPrefs.GetInt ("cardReady") ==  2)
		{
			//反面
			bool correct = IsNotCorrect2(Mathf.Round (spriteBg.transform.rotation.eulerAngles.y));
			if (correct) {				
				PlayerPrefs.DeleteKey ("cardReady");
				print ("in the correct =else");
				yield return null;  
			}		
		}
			
		
//		//正面
		float timeD = Time.deltaTime * 57f;
//		print (timeD);return false;
		

//		print (font+"<<>>"+Correct);
//		print(timeD+		"|WaitForSeconds" + Time.time);
		
		if (Time.time - timeD >= 3 && PlayerPrefs.GetInt ("cardReady") == 1) {
			print ("in the Time=if");
			PlayerPrefs.SetInt ("cardReady", 2);
		} 
		else if (Time.time - timeD >= 3 && PlayerPrefs.GetInt ("cardReady") == 2) {
			print ("in the Time=else");
			PlayerPrefs.DeleteKey ("cardReady");
		}/**/
		
		yield return  new WaitForSeconds(timeD);		
	}

	bool IsNotCorrect2 (float euler)
	{
		print (euler);
		if (270 < euler && euler < 360) {
			spriteBg.enabled = false;
			sprite.enabled = true;
		} else if (195 < euler && euler < 270) {
			spriteBg.enabled = true;
			sprite.enabled = false;
			
		} else if (180 < euler && euler < 195) {
			return true;
		}		
		return false;
		
	}
	
	bool IsCorrect2 (float euler)
	{
		//做减法运算,默认已经旋转180
		print (euler);
		if (euler > 300) {
			return true;
		}
		if (90 < euler && euler < 180) {			
			spriteBg.enabled = true;
			sprite.enabled = false;
		} else if (5 < euler && euler < 90) {
			spriteBg.enabled = false;
			sprite.enabled = true;
		} else if (0 < euler && euler < 5) {
			return isBegin = true;
		}
		return false;		
	}
	
	public void OnTurn ()
	{
		++clickCount;
		isBegin = true;
		qua = Quaternion.Euler (0f, 180f, 0f) * sprite.transform.localRotation;
		quaBg = Quaternion.Euler (0f, 180f, 0f) * spriteBg.transform.localRotation;
		
//		spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime);   
//		sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime);    
	}
	
	public void init()
	{
		for (int i = 0; i < transform.GetChildCount(); i++) {
			spriteBg = transform.GetChild(i).FindChild("Sprite-boxBg").GetComponent<UISlicedSprite>();
			sprite = transform.GetChild(i).FindChild("Sprite-box").GetComponent<UISlicedSprite>();
//			this.OnTurn();
//			print (sprite.spriteName+"|"+spriteBg.spriteName);
		}
		beginTurn=true;
		
	}
	void IsNotCorrect (float euler)
	{
		if (0 < euler && euler < 180) {
			if (0 < euler && euler < 90) {
				//isBegin=false;
				spriteBg.enabled = true;
				sprite.enabled = false;
			}
			if (euler > 90) {					
				if (autoReverse && clickCount != 0) {
					this.OnTurn ();
					
				} else {
					//spriteBg.alpha=1f;			
					spriteBg.enabled = false;
					sprite.enabled = true;
				}
				isBegin = true;
			}
			
			clickCount = 0;	
			//isCorrect=false;
		}
	}
	
	void IsCorrect (float euler)
	{
		if (180 < euler && euler < 360) {				
			if (180 < euler && euler < 270) {
				//转过270度角
				//spriteBg.alpha=1f;			
				spriteBg.enabled = false;
				sprite.enabled = true;
			}
			if (euler > 270) {
				if (autoReverse && clickCount != 0) {
					this.OnTurn ();
					
				} else {
					spriteBg.enabled = true;
					sprite.enabled = false;
				}
				//isBegin=false;
					


			}

		}
	}
	
}
