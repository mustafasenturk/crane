using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpeedTractor : MonoBehaviour {

	static float minSpeed = 117.7f;
	static float maxSpeed = -83.3f;
	static UISpeedTractor thisSpeed;

	void Start(){
		thisSpeed = this;
	}
	public static void ShowSpeed(float speed,float min,float max){
		float ang = Mathf.Lerp (minSpeed,maxSpeed, Mathf.InverseLerp (min, max, speed));
		thisSpeed.transform.eulerAngles = new Vector3 (0,0,ang);
	}
}
