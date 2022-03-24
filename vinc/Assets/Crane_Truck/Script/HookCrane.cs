using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCrane : MonoBehaviour {

	public CraneController craneControllerScript;

	public void UpDownHook(){
	//	if (craneControllerScript.onHook_Bool == false) {
			ConfigurableJoint hookJ = GetComponent<ConfigurableJoint> ();
			SoftJointLimit sofLim = new SoftJointLimit ();
			sofLim.limit = craneControllerScript.limitHook;
			hookJ.linearLimit = sofLim;
			Imp ();
	//	}
	}
	public void Imp(){
		ConstantForce k = GetComponent<ConstantForce> ();
		k.force = new Vector3 (0f, 0.01f, 0f);
	}
	public void RotationHook(){


	}
}
