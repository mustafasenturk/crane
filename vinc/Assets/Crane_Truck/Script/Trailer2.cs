using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer2 : MonoBehaviour {
	public KeyController keyControllerScript;
	public Transform cover0;
	public Transform cover1;
	public Transform cover2;
	public float angelFB_coverLeft = 0f;
	public float angelFB_coverRight = 0f;
	public float angelFB_coverBack = 0f;
	private float smooth = 0.3f;
	private Quaternion tRotation_coverLeft;
	private Quaternion tRotation_coverRight;
	private Quaternion tRotation_coverBack;
	private bool a = true;





	void Start () 
	{
		tRotation_coverLeft = cover0.transform.localRotation;
		tRotation_coverRight = cover1.transform.localRotation;
		tRotation_coverBack = cover2.transform.localRotation;
	}
	void Update (){
		if (Input.GetKeyDown (keyControllerScript.openTrailer) && a == true) {
			tRotation_coverLeft *= Quaternion.AngleAxis (-angelFB_coverLeft, Vector3.forward);
			tRotation_coverRight *= Quaternion.AngleAxis (angelFB_coverRight, Vector3.forward);
			tRotation_coverBack *= Quaternion.AngleAxis (-angelFB_coverBack, Vector3.left);
			a = false;
		} else if (Input.GetKeyDown (keyControllerScript.openTrailer) && a == false) {
			tRotation_coverLeft *= Quaternion.AngleAxis (angelFB_coverLeft, Vector3.forward);
			tRotation_coverRight *= Quaternion.AngleAxis (-angelFB_coverRight, Vector3.forward);
			tRotation_coverBack *= Quaternion.AngleAxis (angelFB_coverBack, Vector3.left);
			a = true;
	}
	cover0.transform.localRotation= Quaternion.Lerp (cover0.transform.localRotation, tRotation_coverLeft , 10 * smooth * Time.deltaTime);
		cover1.transform.localRotation= Quaternion.Lerp (cover1.transform.localRotation, tRotation_coverRight , 10 * smooth * Time.deltaTime);
		cover2.transform.localRotation= Quaternion.Lerp (cover2.transform.localRotation, tRotation_coverBack , 10 * smooth * Time.deltaTime);
	}





}
