using UnityEngine;
using System.Collections;

public class ObjectMoveByMouse : MonoBehaviour {

	public GameObject TargetObject;
 
	private bool IsMouseDown = false;
	private Vector3 PositionStart;
	private Quaternion StartRotation;
 
	private float yMinLimit = -20;
	private float yMaxLimit = 80;
	private float x = 0.0f;
	private float y = 0.0f;
	private float xSpeed = 250.0f;
	private float ySpeed = 120.0f;
	private float Spring = 0.02f;
 
	private int FrameRate = 0;
	void Start () {
		if(TargetObject)
		{
			Vector3 angles = TargetObject.transform.eulerAngles; print(TargetObject.transform.eulerAngles);
			x = angles.x;
			y = angles.y;
			if(TargetObject.rigidbody) TargetObject.rigidbody.freezeRotation = true;
		}
	}
 
	void Update () {
		if(IsMouseDown)
		{
			x += Input.GetAxis("Mouse X") * xSpeed * Spring;
			y -= Input.mousePosition.y * ySpeed * Spring;
		}
	}
 
	void LateUpdate()
	{
		if(IsMouseDown)
		{
			y = ClampAngle(y,yMinLimit,yMaxLimit);
			Quaternion rotation = Quaternion.Euler(0,-x,0);
			TargetObject.transform.rotation = rotation;
		}
	}
 
	void OnMouseDown()
	{
		PositionStart = Input.mousePosition;
		StartRotation = TargetObject.transform.rotation;
		IsMouseDown = true;
	}
 
	void OnMouseExit()
	{
		//IsMouseDown = false;
	}
 
	void OnMouseUp()
	{
		IsMouseDown = false;
	}
 
	static float ClampAngle(float angle, float min, float max)
	{
		if(angle<-360) angle += 360;
		if(angle>360) angle -= 360;
		return Mathf.Clamp(angle,min,max);
	}
}
