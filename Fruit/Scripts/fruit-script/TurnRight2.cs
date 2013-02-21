using UnityEngine;
using System.Collections;

public class TurnRight2 : MonoBehaviour
{
	/// <summary>
	/// 绕sprite中心左右旋转
	/// </summary>
	
//	public delegate void deleEnemyDie();
//	public event deleEnemyDie EvenEnemyDie;
	public delegate void clicked(string name) ;
	public event clicked eventClicked;
	
	public UISprite sprite;
	public UISprite spriteBg;
	
	//只有精灵脚本
	private GameObject target;
	private bool isBegin = false;

	public bool autoReverse = false;
	int clickCount = 0;
//	Transform trans;
	UISlicedSprite sp;
	// Use this for initialization
	void Start ()
	{		
		sprite.enabled = false;
		target = GameObject.FindWithTag ("Player");
		
		if(target != null){
			ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas>();
			ra.EventReplace +=	new ExampleAtlas.replaceSprite(OnClick);
			//sp=target.transform.GetComponentInChildren<UISprite>();
			//trans = target.transform.FindChild("UISprite");
			sp = target.transform.GetComponent<UISlicedSprite>();	
		}
	}
	void Update () {
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
		}*/
		
			
		if (isBegin) {
						
			spriteBg.transform.rotation = Quaternion.Slerp (spriteBg.transform.rotation, quaBg, Time.deltaTime * 3);   
			sprite.transform.rotation = Quaternion.Slerp (sprite.transform.rotation, qua, Time.deltaTime * 3);     		

			float vEuler = Mathf.Round (spriteBg.transform.rotation.eulerAngles.y);
			//反面
			IsNotCorrect (vEuler);
			//正面
			IsCorrect (vEuler);
			
		}
	}
	void OnClick ()
	{
		++clickCount;
		if (sprite != null && spriteBg != null 	) {//		&& !isBegin
						
			isBegin = true;			
			qua = Quaternion.Euler (0f, 180f, 0f) * sprite.transform.localRotation;	
			quaBg = Quaternion.Euler (0f, 180f, 0f) * spriteBg.transform.localRotation;
//			print(RegexUtil.RemoveNotNumber( sp.spriteName)+"=="+RegexUtil.RemoveNotNumber( sprite.spriteName ));
			
			if(target !=null){
				if(RegexUtil.RemoveNotNumber( sp.spriteName) == RegexUtil.RemoveNotNumber( sprite.spriteName )){
					StartCoroutine(playReplace());
				}
			}
		}		
	}
	IEnumerator playReplace()
	{
		ExampleAtlas ra = target.transform.GetComponent<ExampleAtlas>();
//		ra.init();
		autoReverse = false;
		yield return new WaitForSeconds(0.9f);
		ra.NextSprite(sp.spriteName);
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
				if(autoReverse && clickCount!=0)
				{
					this.OnClick();
					
				}else{
					//spriteBg.alpha=1f;			
					spriteBg.enabled = false;
					sprite.enabled = true;
				}
				isBegin	=true;
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
				if(autoReverse&& clickCount!=0)
				{
					this.OnClick();
					
				}else{
					spriteBg.enabled = true;
					sprite.enabled = false;
				}
				//isBegin=false;
					


			}

		}
	}
}
