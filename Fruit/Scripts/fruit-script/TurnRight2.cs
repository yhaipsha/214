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
	int font = 0;
	Quaternion qua;
	Quaternion quaBg;
	UISlicedSprite spHead;
	// Use this for initialization
	void Start ()
	{		
		Correct = new Vector3 (0f, 180f, 0f);
		sprite.enabled = false;
		target = GameObject.FindWithTag ("Player");
		Globe.sameSize = new System.Collections.Generic.Dictionary<string, int> ();
		Globe.differentSize = new System.Collections.Generic.Dictionary<string, int> ();
		Globe.tempGameObject = new System.Collections.Generic.List<UnityEngine.GameObject>();
		if (target != null) {
			ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas> ();
			ra.EventReplace += new ExampleAtlas.replaceSprite (OnClick);
			spHead = target.transform.GetComponent<UISlicedSprite> ();	
		}
	}

	void LateUpdate2 ()
	{
		if (PlayerPrefs.GetInt ("cardReady") == 2) {
			waitSecond3 ();
			StartCoroutine (show ());
			PlayerPrefs.DeleteKey ("cardReady");
		}
	}

	void Update ()
	{
		if (PlayerPrefs.GetInt ("cardReady") == 1) {
			StartCoroutine (show ());
			//PlayerPrefs.SetInt("cardReady",2);
		}
      
		if (isBegin) {

			spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime * 3);
			sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime * 3);

			float vEuler = Mathf.Round (spriteBg.transform.rotation.eulerAngles.y);
			//反面
			IsNotCorrect (vEuler);
			//正面
			IsCorrect (vEuler);

		}
		/*
        if(Input.GetMouseButtonDown(0))
        {
            Ray r= Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(r.origin,r.direction,out hit))
            {
                print (hit.transform.name+"||"+hit.distance);
//				if(hit.transform.name=="TextMesh")
//				{
//					Application.LoadLevel("t1");
//				}
            }
        }
		*/

	}
	
	IEnumerator waitSecond3 ()
	{
		yield return new WaitForSeconds(3);
	}

	IEnumerator show ()
	{
		qua = Quaternion.Euler (Correct) * sprite.transform.localRotation;	
		quaBg = Quaternion.Euler (Correct) * spriteBg.transform.localRotation;
					
		spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime);   
		sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime);     		
		
		float vEuler = Mathf.Round (spriteBg.transform.rotation.eulerAngles.y);
		//反面
		IsNotCorrect (vEuler);
		//正面
		IsCorrect (vEuler);
		float timeD = Time.deltaTime * 57f;
		yield return  new WaitForSeconds(timeD);		
//		print (font+"<<>>"+Correct);
//		print(timeD+		"|WaitForSeconds" + Time.time);
		if (Time.time - timeD >= 3 && PlayerPrefs.GetInt ("cardReady") == 1) {
			PlayerPrefs.SetInt ("cardReady", 2);
		}	
	}
	
	IEnumerator showWait3 ()
	{
		yield return new  WaitForSeconds(Time.deltaTime *114.0f);		
	}

	public void Turn ()
	{
		isBegin = true;
		qua = Quaternion.Euler (0f, 180f, 0f) * sprite.transform.localRotation;
		quaBg = Quaternion.Euler (0f, 180f, 0f) * spriteBg.transform.localRotation;
		
		spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime);   
		sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime);    
	}

	void OnClick ()
	{		
		++clickCount;
		if (sprite != null && spriteBg != null) {//		&& !isBegin
			
			isBegin = true;
			qua = Quaternion.Euler (0f, 180f, 0f) * sprite.transform.localRotation;
			quaBg = Quaternion.Euler (0f, 180f, 0f) * spriteBg.transform.localRotation;
			
			switch (PlayerPrefs.GetInt ("NowMode")) {
			case 1:
				mode1 ();
				break;
			case 2:
				mode2 ();
				break;
			}
		}
	}

	void mode1 ()
	{//"标准模式-看3秒，找出指定水果，限错3次";
		string theNumber = RegexUtil.RemoveNotNumber (sprite.spriteName);
		string head = RegexUtil.RemoveNotNumber (spHead.spriteName);
		if (head == theNumber) {
			//signName = "Right";
				
			if (Globe.sameSize.ContainsKey (spHead.spriteName)) {
				Globe.sameSize [spHead.spriteName]++;
			} else
				Globe.sameSize.Add (spHead.spriteName, 1);
				
				
		} else {
			//signName = "Wrong";
				
			if (Globe.differentSize.ContainsKey (transform.name)) {
				Globe.differentSize [transform.name]++;
			} else
				Globe.differentSize.Add (transform.name, 1);
		}						
			

		ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas> (); 
		if (target != null) {
			if (head == theNumber) {
				StartCoroutine (playReplace ());
				autoReverse = false;
//					SendMessageUpwards("NextSprite",spHead.spriteName);
				ra.NextSprite (spHead.spriteName);
			} else {				
					
				transform.parent.parent.FindChild ("LabelTime").GetComponent<UILabel> ().text = (3 - Globe.differentSize.Count).ToString ();
				if (Globe.differentSize.Count >= 3) {
					ra.toPanelWin (0);
				}
			}

		}
	}

	private GameObject lastGo;

	void mode2 ()
	{//经典模式-看5秒找相同水果，限错N次";

		if (Globe.askatlases.Count >0 && Globe.thisPanel  != null && Globe.askatlases[0] != transform.name) {
			
			UISprite ltsp = Globe.thisPanel.FindChild ("Sprite-box").GetComponent<UISprite> ();
			UISprite tsp = transform.FindChild ("Sprite-box").GetComponent<UISprite> ();
		
			print (ltsp.spriteName + "?" + tsp.spriteName);
			if (ltsp.spriteName == tsp.spriteName) {
				playReplace ();
				Destroy (Globe.thisPanel.gameObject);
				Destroy (gameObject);
				Globe.askatlases.Clear();
			} else {
				;
//				StartCoroutine(show());
				Globe.thisPanel.gameObject.GetComponent<TurnRight2> ().Turn ();
//				this.OnClick();
			}
			
			Globe.thisPanel=null;
			Globe.askatlases.Clear();
			
		}else
		
		if (!Globe.askatlases.Contains (transform.name) ){
			Globe.askatlases.Add (transform.name);
//			print(Globe.thisPanel+"?");
			Globe.thisPanel = transform;
//			lastGo = gameObject;
			print (transform.name);
			autoReverse=false;
		}
		
		if(transform.parent.GetChildCount()<=0)
		{
			print ("----------");
			//transform.parent.parent
			GameWinLayer gw = Globe.getPanelOfParent(transform.parent.parent,1,"Panel - GameWin").GetComponent<GameWinLayer>();
			gw.init(1);
			
		}
			
	}

	void mode3 ()
	{//"挑战模式-限时找相同水果，不限错次数";
		
	}

	IEnumerator playReplace ()
	{
		//		ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas>();
		//		ra.init();
		//		autoReverse = false;
		yield return new WaitForSeconds(0.9f);
		//		ra.NextSprite(sp.spriteName);
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
