using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
	public bool autoReverse = false;
	public Transform transExample;
	public Transform transTimes;
	public Transform transLable;
	int initialized = 0;
	UISlicedSprite spHead;
	ExampleAtlas examObj;
	float backTime;//用于计数的变量
	
	
	int clickCount = 0;
	private bool isBegin = false;
	Quaternion qua;
	Quaternion quaBg;
	UISprite sprite;
	UISprite spriteBg;
	bool beginTurn = false;

	void Start ()
	{				
		backTime = 30;//假设从100开始倒数，这个数值你可以自行修改呀
//		target = GameObject.FindWithTag ("Player");
		
		Globe.sameSize = new System.Collections.Generic.Dictionary<string, int> ();
		Globe.differentSize = new System.Collections.Generic.Dictionary<string, int> ();
		Globe.tempGameObject = new System.Collections.Generic.List<UnityEngine.GameObject> ();
		
		if (transExample != null) {
			examObj = transExample.GetComponent<ExampleAtlas> ();
			examObj.EventReplace += new ExampleAtlas.replaceSprite (appriseExam);
			spHead = transExample.GetComponent<UISlicedSprite> ();	
		}
	}

	void Update ()
	{
		if (initialized == 2) {
			initialized = 0;
			examPlay ();
			init (2);
			PlayerPrefs.DeleteKey ("cardReady");
		}		
		if (PlayerPrefs.GetInt ("NowMode") == 3) {
			print (backTime.ToString ("F0"));//每帧都更新时间变化，F0表示小数点后显示0位，如果你需要可以改变0为相应的位数！		
			backTime = backTime - Time.deltaTime;//总时间i减去每帧消耗的时间，当然就等于当前时间啦，对吧？
		}
		
//		if (PlayerPrefs.GetInt ("cardReady") == 1 && initialized != 0) {
//			StartCoroutine (show ());
//		}
	}

	void clickedCount (string spriteName, string spriteName2, string name)
	{
		if (spriteName == spriteName2) {
			//answer is right == 相同的点击不计数 
			if (!Globe.sameSize.ContainsKey (name)) {
				Globe.sameSize.Add (name, 1);
			} 
			
			autoReverse = false;
			appriseExam ();
		} else {
			Globe.errorCount--;//= ++clickCount;
			print (Globe.errorCount);
			//answer is wrong == 相同的点击计数
//			if (Globe.differentSize.ContainsKey (name)) {
//				Globe.differentSize [name]++;
//			} else
//				Globe.differentSize.Add (name, 1);
			
			turnTo (name, "TurnBack");
			UpdateTime (Globe.errorCount);
				
			if (Globe.errorCount <= 0) {
				examObj.toPanelWin (0);
			}
		}
		
	}

	void examPlay ()
	{
		if (transExample != null) {
			transExample.GetComponent<UISlicedSprite> ().enabled = true;
			transExample.animation.Play ("Center_UpRight");
		}
	}
	
	void mode1 (string name)
	{//"标准模式-看3秒，找出指定水果，限错3次";
		string theNumber = RegexUtil.RemoveNotNumber (getSpriteName (name));//print (spHead.spriteName);
		string head = RegexUtil.RemoveNotNumber (spHead.spriteName);
		
		clickedCount (head, theNumber, name);						
		/*	
		if (head == theNumber) {
			autoReverse = false;
			appriseExam ();
				
		} else {				
			turnBack (name, "TurnBack");
			UpdateTime (3 - Globe.differentSize.Count);
				
			if (Globe.differentSize.Count >= 3) {
				examObj.toPanelWin (0);
			}
		}*/
	}

	void mode2 (string name)
	{//经典模式-看5秒找相同水果，限错N次";

		if (Globe.askatlases.Count > 0 && Globe.thisPanel != null && Globe.askatlases [0] != name) {
			
			UISprite ltsp = Globe.thisPanel.FindChild ("Sprite-box").GetComponent<UISprite> ();
//			UISprite tsp =  transform.FindChild ("Sprite-box").GetComponent<UISprite> ();
			string spriteName = getSpriteName(name);
			print (ltsp.spriteName + "?" + spriteName);
			if (ltsp.spriteName == spriteName) {
//				playReplace ();
				Destroy (Globe.thisPanel.gameObject);
				Destroy(getTransFatherOfSprite(name).gameObject);
				Globe.askatlases.Clear ();
			} else {
				;
//				StartCoroutine(show());
				Globe.thisPanel.gameObject.GetComponent<TurnRight2> ().Turn ();
//				this.OnClick();
			}
			
			Globe.thisPanel = null;
			Globe.askatlases.Clear ();
			
		} else if (!Globe.askatlases.Contains (name)) {
			//记录上次精灵
			Globe.askatlases.Add (name);
			Globe.thisPanel = transform;
			print (name);
			autoReverse = false;
		}
		
//		if (transform.parent.GetChildCount () <= 0) {
//			print ("----------");
//			GameWinLayer gw = Globe.getPanelOfParent (transform.parent.parent, 1, "Panel - GameWin").GetComponent<GameWinLayer> ();
//			gw.init (1);
//			
//		}
			
	}
	
	void appriseExam ()
	{
		if (examObj != null) {
			examObj.NextSprite (spHead.spriteName);
//			print (spHead.spriteName);
		}
	}

	string getSpriteName (string name)
	{
		return transform.FindChild (name).FindChild ("Sprite-box").GetComponent<UISlicedSprite> ().spriteName;
	}
	Transform getTransFatherOfSprite(string childrenName)
	{
		return transform.FindChild (childrenName);
	}
	
	void turnTo(string spriteName, string animateName)
	{
		transform.FindChild (spriteName).animation.Play (animateName);
//		animation.PlayQueued("TurnBack",QueueMode.PlayNow);
	}

	void UpdateTime (int score)
	{
		if (transTimes != null) {
			transTimes.GetComponent<UILabel> ().text = score.ToString ();
		}
	}
	
	IEnumerator show ()
	{				
		if (initialized == 1) {
			yield return  new WaitForSeconds(4.0f);
			init (-1);			
		} 
		
	}

	public void init (int state)
	{		
		for (int i = 0; i < transform.GetChildCount(); i++) {
			Transform _trans = transform.GetChild (i);
//			Animation animate = _trans.animation;
			
			if (state == 1) {
				_trans.animation.Play ("TurnGo");
			} else if (state == 2) {
				_trans.animation.Stop ();
			} else if (state == -1) {
				_trans.animation ["TurnGo"].time = 0;
				_trans.animation.Play ("TurnGo");
			}
		}
		
		
		if (state == 1) {
			initialized = 1;
		} else if (state == -1) {
			initialized = 2;
		}		
	}

	bool IsNotCorrect2 (float euler)
	{
//		print (euler);
//		if (euler ==0) {
//			return false;
//		}
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
//		print (euler);
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
	
	void OnTurn ()
	{
		isBegin = true;
		qua = Quaternion.Euler (0f, 180f, 0f) * sprite.transform.localRotation;
		quaBg = Quaternion.Euler (0f, 180f, 0f) * spriteBg.transform.localRotation;
		
//		spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime);   
//		sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime);    
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
				if (autoReverse) {
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
				if (autoReverse) {
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
