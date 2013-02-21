using UnityEngine;
using System.Collections.Generic;

public class RondamAtlas : MonoBehaviour {
	
	public delegate void replaceSprite();
	public event replaceSprite EventReplace;
	
	public GameObject prefabAtlas;
	public UIAtlas tu ;
	public UISprite sprite;
	public UISprite spriteBg;

//	int[] OrcDifficulty  = new int[5] { 10,  5,  2,  2,  2 };
	
	void Start () {
//		sprite = Scenes/UI3D/AtlasAnimate2
		//tu = Resources.Load("AtlasAnima2", typeof(UIAtlas)) as UIAtlas;
		//tuu = Resources.Load("Cards/ 001", typeof(GameObject )) as GameObject ; 
		 ;
		if(tu == null)
			Debug.Log("is null ");
		else
		{
			NextSprite("");
			//this.EventReversed+=	new TurnRight.reversed(NextSprite);
			//GameObject.Find()
//			RondamAtlas ra = target.transform.GetComponent<RondamAtlas>();
//			ra.EventReversed+=new RondamAtlas.reversed(NextSprite);
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//this.EventReversed+=	new TurnRight.reversed(NextSprite);
	}
	Dictionary<string,int> myDir;
	
	string spName = "";
	int radInt=0;
	public void NextSprite(string name)
	{
		
		
		/*	*/
		int tmp = Random.Range(-1, 7);			
			if(tmp<0)
				tmp=0;
			if(tmp>6)
				tmp=6;
		/*
		if(!name.Equals("")){
			//UIItemStorageMy.dir.Remove(name);
			//UIItemStorageMy.dir
			foreach (KeyValuePair<string, int> item in UIItemStorageMy.dir) {
				if(name.Equals(item.Key))
				{
					--item.Value;
					if(item.Value == 0)
						UIItemStorageMy.dir.Remove(item.Key);					
				}
			
         	}
			radInt = Random.Range(0,6);
			
		}
		*/
		
		
		sprite.spriteName = tu.spriteList[tmp].name;
		sprite.transform.rotation=Quaternion.Euler(0f, 180f, 0f) ;
		sprite.MakePixelPerfect(); 
		
		//return sprite.spriteName;
	}
	
}
