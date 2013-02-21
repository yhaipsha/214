using UnityEngine;
using System.Collections;

public class SpriteAnimate : MonoBehaviour
{
	//播放动画与不播放
	bool isPlayAnim = false;
	//得到精灵对象
	GameObject animObj = null;
	
	void Start ()
	{
		//得到精灵对象
		animObj = GameObject.Find ("Sprite_F1");
	}

	void OnClick ()
	{
		if (isPlayAnim) {
			//停止动画
			isPlayAnim = false;
			//销毁UISpriteAnimation组件
			Destroy (animObj.GetComponent<UISpriteAnimation> ());
			UISprite ui = animObj.GetComponent<UISprite> ();
			string name = ui.atlas.spriteList [0].name;
			ui.spriteName = name;

		} else {

			//播放播放
			isPlayAnim = true;
			//加入播放动画组件
			animObj.AddComponent ("UISpriteAnimation");

			//设置播放动画的速度
			//1-60之间数值越大播放速度越快
			UISpriteAnimation uiAnim = animObj.GetComponent<UISpriteAnimation> ();
			uiAnim.framesPerSecond = 10;

		}

	}

}
