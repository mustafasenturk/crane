using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trailer : MonoBehaviour {
	public KeyController keyControllerScript;
	public ONOFFTruckCrane oNOFFTruckCraneScript;
	public Rigidbody rbTrailer;
	public Transform[] wTransform;
	public WheelCollider[] wCol;
	public Transform centerOfMass;
	public float motorTrailer = 0f;
	private float[] rotValue;
	public Image iconPoint;
	public GameObject pointTruck;
	public GameObject pointTrailer;
	private float dist = 0f;
	public bool onKey = false;
	public bool key_joinTrailer_Bool = true;
	public Rigidbody truck;
	public ConfigurableJoint trailerJoint;
	public GameObject standTrailer;
	public Vector3 standTrailer_UP;
	public Vector3 standTrailer_DOWN;
	public AudioSource soundTrailer;
	public AudioClip soundTrailer_Clip;


	void Start(){
		rotValue = new float[wCol.Length];
		GetComponent<Rigidbody> ().centerOfMass = new Vector3 ((centerOfMass.transform.localPosition.x * transform.localScale.x),(centerOfMass.transform.localPosition.y * transform.localScale.y),(centerOfMass.transform.localPosition.z * transform.localScale.z));
	}
	void Update(){
		WheelTrailer ();
		if (pointTrailer) {
			 dist = Vector3.Distance (pointTrailer.transform.position, pointTruck.transform.position);
		}
		if (dist < 0.1f && key_joinTrailer_Bool == true) {
			iconPoint.enabled = true;
			onKey = true;
		} else {
			iconPoint.enabled = false;
			onKey = false;
		}
		if (Input.GetKeyDown (keyControllerScript.joinTrailer) && key_joinTrailer_Bool == true && onKey == true && oNOFFTruckCraneScript.startTruck_Bool == false) {
			iconPoint.enabled = false;
			key_joinTrailer_Bool = false;
			JointTrailerTruckON ();
			soundTrailer.PlayOneShot (soundTrailer_Clip,1);
		} else if (Input.GetKeyDown (keyControllerScript.joinTrailer) && key_joinTrailer_Bool == false && oNOFFTruckCraneScript.startTruck_Bool == false) {
			key_joinTrailer_Bool = true;
			JointTrailerTruckOFF ();
			soundTrailer.PlayOneShot (soundTrailer_Clip,1);
		}
	}
	void WheelTrailer(){
		if (wCol.Length > 0) {
			RaycastHit hitTra;
			for (int i = 0; i < wCol.Length; i++) {
				Vector3 CollCenterTrailer = wCol [i].transform.TransformPoint (wCol [i].center);
				if (Physics.Raycast (CollCenterTrailer, -wCol [i].transform.up, out hitTra, (wCol [i].suspensionDistance + wCol [i].radius) * transform.localScale.y)) {
					wTransform [i].transform.position = hitTra.point + (wCol [i].transform.up * wCol [i].radius) * transform.localScale.y;
				} else {
					wTransform [i].transform.position = CollCenterTrailer - (wCol [i].transform.up * wCol [i].suspensionDistance) * transform.localScale.y;
				}
				wTransform [i].transform.rotation = wCol [i].transform.rotation * Quaternion.Euler (rotValue [i], 0, wCol [i].transform.rotation.z);
				rotValue [i] += wCol [i].rpm * (4) * Time.deltaTime;
			}
		}

	}
	void FixedUpdate(){
		foreach (WheelCollider onTrailer in wCol) {
			if (onTrailer.isGrounded)
				onTrailer.motorTorque = motorTrailer;
			else
				onTrailer.motorTorque = 0;
		}
	}


	public void JointTrailerTruckON(){
		trailerJoint.GetComponent<ConfigurableJoint> ().connectedBody = truck;
		standTrailer.transform.localPosition = standTrailer_UP;
		motorTrailer = 0.01f;
	}
	public void JointTrailerTruckOFF(){
		trailerJoint.GetComponent<ConfigurableJoint> ().connectedBody = null;
		standTrailer.transform.localPosition = standTrailer_DOWN;
		motorTrailer = 0;
	}

}
