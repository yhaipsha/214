using UnityEngine;
using System.Collections;

public class TurnRight2 : MonoBehaviour
{
	/// <summary>
	/// 绕sprite中心左右旋转
	/// </summary>
	
//	public delegate void deleEnemyDie();
//	public event deleEnemyDie EvenEnemyDie;
	public delegate void clicked (string name) ;

	public event clicked eventClicked;
	
	public UISprite sprite;
	public UISprite spriteBg;
	
	//只有精灵脚本
	private GameObject target;
	private bool isBegin = false;
	public bool autoReverse = false;
	int clickCount = 0;
	Vector3 Correct = Vector3.zero;
	int font =0;
	UISlicedSprite sp;
	// Use this for initialization
	void Start ()
	{		
		Correct = new Vector3 (0f, 180f, 0f);
		sprite.enabled = false;
		target = GameObject.FindWithTag ("Player");
		
		if (target != null) {
			ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas> ();
			ra.EventReplace += new ExampleAtlas.replaceSprite (OnClick);
			sp = target.transform.GetComponent<UISlicedSprite> ();	
		}
	}

	void Update ()
	{
			
		
		if (PlayerPrefs.GetInt ("GameWindow") == 1) {	
			font=-1;
			StartCoroutine ("show"); 	

			
//			Ray r = Camera.mainCamera.ScreenPointToRay (Input.mousePosition);
//			RaycastHit hit;
//			if (Physics.Raycast (r.origin, r.direction, out hit)) {
//
//				if (hit.transform.name == "TemplatePlayer(Clone)") {
//
//					qua = Quaternion.Euler (0f, 180f, 0f) * sprite.transform.localRotation;	
//					quaBg = Quaternion.Euler (0f, 180f, 0f) * spriteBg.transform.localRotation;
//					
//					spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime * 3);   
//					sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime * 3);     		
//		
//					float vEuler = Mathf.Round (spriteBg.transform.rotation.eulerAngles.y);
//					//反面
//					IsNotCorrect (vEuler);
//					//正面
//					IsCorrect (vEuler);
//					
//				}
//			}/**/
		}/**/
		if (PlayerPrefs.GetInt ("GameWindow") == -1) {
			Correct = new Vector3 (0f, -180f, 0f);
			StartCoroutine (showWait3 ()); 
			font=2;
			StartCoroutine (show ()); 
			PlayerPrefs.DeleteKey("GameWindow");
		print ( PlayerPrefs.GetInt("GameWindow"));
		}
		/*			
		if (isBegin) {						
			spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime * 3);   
			sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime * 3);     		

			float vEuler = Mathf.Round (spriteBg.transform.rotation.eulerAngles.y);
			//反面
			IsNotCorrect (vEuler);
			//正面
			IsCorrect (vEuler);
			
		}*/
	}

	IEnumerator show ()
	{
		qua = Quaternion.Euler (Correct) * sprite.transform.localRotation;	
		quaBg = Quaternion.Euler (Correct) * spriteBg.transform.localRotation;
					
		spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime);   
		sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime);     		
		
		float vEuler = Mathf.Round (spriteBg.transform.rotation.eulerAngles.y);
		//反面
//		IsNotCorrect (vEuler);
		//正面
		IsCorrect (vEuler);
		
		yield return  new WaitForSeconds(Time.deltaTime * 57f);		
		print (font+"<<>>"+Correct);
		print("WaitForSeconds" + Time.time);
		PlayerPrefs.SetInt ("GameWindow", font);
	}
	
	IEnumerator showWait3 ()
	{
		yield return new  WaitForSeconds(Time.deltaTime *114.0f);		
	}

	void OnClick ()
	{		/*
		if (sprite != null && spriteBg != null) {//		&& !isBegin
			++clickCount;
			isBegin = true;			
			qua = Quaternion.Euler (0f, 180f, 0f) * sprite.transform.localRotation;	
			quaBg = Quaternion.Euler (0f, 180f, 0f) * spriteBg.transform.localRotation;
//			print(RegexUtil.RemoveNotNumber( sp.spriteName)+"=="+RegexUtil.RemoveNotNumber( sprite.spriteName ));
			
			if (target != null) {
				
				
				ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas> ();
				if (RegexUtil.RemoveNotNumber (sp.spriteName) == RegexUtil.RemoveNotNumber (sprite.spriteName)) {
					StartCoroutine (replaceWite ());
					autoReverse = false;
					ra.NextSprite (sp.spriteName);
				} else {
					Globe.errorCount++;
//					if (Globe.errorCount >= 3) {
//						//goto 错误界面
//						ra.toPanelWin(0);
//					}
					print (Globe.errorCount + "|" + clickCount);
				}
			}
		}*/
	}

	void OnCollisionEnter (Collision collision)
	{
		print (collision.gameObject.name);
		foreach (ContactPoint contact in collision.contacts) {
			

			Debug.DrawRay (contact.point, contact.normal, Color.white);
		}
		if (collision.relativeVelocity.magnitude > 2)
			audio.Play ();

	}

	IEnumerator replaceWite ()
	{
		yield return new WaitForSeconds(0.9f);
		
//		ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas> ();
//		autoReverse = false;
//		ra.NextSprite (sp.spriteName);
	}
	
	Quaternion qua;
	Quaternion quaBg;
	
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
					this.OnClick ();
					
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
					this.OnClick ();
					
				} else {
					spriteBg.enabled = true;
					sprite.enabled = false;
				}
				//isBegin=false;
					


			}

		}
	}
}
