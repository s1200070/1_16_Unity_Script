using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public Transform rotatetarget;
	public float xspeed = 100;
	public float yspeed = 100;
	public Transform targetObj;
	float distance = 3.0f;
	float dy = 1.0f;

	private float x = 0.0f;
	private float y = 0.0f;

	public float yMinLimit = -20;
	public float yMaxLimit = 80;



	// Use this for initialization
	void Start () {
		var angles = rotatetarget.eulerAngles;
		x = angles.y;
		y = angles.x;

		rotatetarget.position = Quaternion.Euler(y,x,0)*(new Vector3(0.0f,dy,-distance))+targetObj.position;
		if(rigidbody){
			rigidbody.freezeRotation = true;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			x -= Input.GetAxis("Mouse X")*0.1f*xspeed;
			y -= Input.GetAxis("Mouse Y")*0.1f*yspeed;
			y = ClampAngle(y,yMinLimit,yMaxLimit);
			var rotation = Quaternion.Euler(y,x,0);
			Vector3 position = rotation*(new Vector3(0.0f,dy,-distance))+targetObj.position;
			rotatetarget.rotation = rotation;
			rotatetarget.position = position;
		}
		rotatetarget.position = Quaternion.Euler(y,x,0)*(new Vector3(0.0f,dy,-distance))+targetObj.position;
	}

	public static float ClampAngle(float angle, float min, float max){
		if(angle < -360){
			angle+= 360;
		}
		if(angle > 360){
			angle -= 360;
		}
		return Mathf.Clamp(angle,min,max);
	}

}
