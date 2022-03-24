using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCabine : MonoBehaviour {
	public KeyController keyControllerScript;
	public CameraOrbitCar cameraOrbitCarScript;
	public Transform cabina;
	private float x = 0f;
	private float y = 0f;
	float xSpeed= 250f;
	float  ySpeed= 120f;
	private float yMinLi= -30f;
	private float yMaxLi= 85f;
	public float distance = 6f;


	void  LateUpdate (){
		if (cabina) {
				x += Input.GetAxis ("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f;
				y = ClampAngle (y, yMinLi, yMaxLi);
				Quaternion rotation = Quaternion.Euler (y, x, 0);
			Vector3 position = rotation * new Vector3 (0f, 0f, -distance) + cabina.position;

				transform.rotation = rotation;
				transform.position = position;
			}
		if (Input.GetKeyDown (keyControllerScript.cameraOnMouse)) {
			xSpeed = 0.0f;
			ySpeed = 0.0f;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}else if (Input.GetKeyUp(keyControllerScript.cameraOnMouse)){
			xSpeed= 250f;
			ySpeed= 120f;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
		static float ClampAngle ( float angle ,   float min ,   float max  ){

			if (angle < -360)
				angle += 360;
			if (angle > 360)
				angle -= 360;
			return Mathf.Clamp (angle, min, max);
		}
}
