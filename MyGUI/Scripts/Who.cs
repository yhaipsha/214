using UnityEngine;
using System.Collections;

public class Who : MonoBehaviour {
	
	
	public Transform target;
	private bool isBegin=false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	Quaternion qua;
	void Update () {
			
		if (isBegin)
   		{
      		//target.position = Quaternion.Slerp(target.position,	qua, Time.deltaTime * 3);
             //target.eulerAngles = Vector3(0, target.eulerAngles.y, 0);
			
			//target.localPosition = Quaternion.FromToRotation(v2,v3);
			
   		}
			
	}
	Vector3 v3= new Vector3(0f, 1f, 0f);	
	TweenPosition tw ;
	
	void OnClick()
	{
		if (target != null)
		{			
			isBegin = true;			
				
			//target.transform.Translate(v3);//Vector3.up * Time.deltaTime * Speed); 
			// turn on forover			
			//target.localRotation = Quaternion.Euler(0f, 180, 0f) * target.localRotation;			
			//target.rotation = Quaternion.Slerp(target.rotation, Quaternion.Euler(0f, 180, 0f) * target.localRotation, Time.deltaTime * 3);
			
			/**/
			tw = target.GetComponent<TweenPosition>();
			//tw.method = UITweener.Method.EaseInOut;
			//tw.style = UITweener.Style.Once;
			//tw.from = new Vector3(0f, -10f, 0f);
			//tw.to = new Vector3(0f,250f,0f);
			if(tw != null)
			
			Debug.Log(tw.from+"|"+tw.to);
			else
				Debug.Log("is null");
			
			//tw.duration = 0.5f;			
			tw.Toggle();
			
			Debug.Log(tw.hideFlags+",");			
			if(tw.hideFlags == HideFlags.NotEditable)
			{	tw.Reset();
				tw.hideFlags = HideFlags.HideAndDontSave;
			}
			else
			{	tw.Play(true);	
				tw.hideFlags=HideFlags.NotEditable;
			}

		}		
		
	}

	
}
