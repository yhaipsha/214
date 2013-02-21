using UnityEngine;
using System.Collections;

public class DynAtlas : MonoBehaviour {
	
	public UISprite sprite;
	private UIAtlas tu = null;
	// Use this for initialization
	void Start () {
//		sprite = Scenes/UI3D/AtlasAnimate2
		tu = Resources.Load("AtlasAnima2", typeof(UIAtlas)) as UIAtlas;

		sprite.atlas = Resources.Load("AtlasAnima2", typeof(UIAtlas)) as UIAtlas;
		StartCoroutine(Play());
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	IEnumerator Play()
	{				
		foreach (UIAtlas.Sprite item in sprite.atlas.spriteList) {
			
			sprite.spriteName = item.name;  //这里跟上这个atlas里面的图片的名称		
			sprite.MakePixelPerfect();    //这里记得要make一下，不然_Player的大小是不会变化的，看你个人需要		
			yield return new WaitForSeconds(0.3f);
		}			
		Debug.Log("over:资源加载完成");		
		StartCoroutine(Play());
	}
}
