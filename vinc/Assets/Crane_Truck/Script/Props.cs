using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Props : MonoBehaviour {
	public KeyController keyControllerScript;
	public Image imageHook;
	public bool cargoCapture_Bool = true;
	private bool onKey = false;
	public Rigidbody hookCraneR;
	public GameObject pointHook;
	public Transform pointHookCargo;
	public Transform pointCargo1;
	public Transform pointCargo2;
	public Transform pointCargo3;
	public Transform pointCargo4;
	private bool lineHook_Bool = false;
	public Material matLineRen;
	public GameObject butonac;

    public void bagla()

	{
		FixedJoint cargo = gameObject.AddComponent<FixedJoint>();
        cargo.GetComponent<FixedJoint>().connectedBody = hookCraneR;
        imageHook.enabled = false;
        butonac.SetActive(false);
        lineHook_Bool = true;
        cargoCapture_Bool = false;	
	}


    public void kes()

	{
		FixedJoint cargo = gameObject.GetComponent<FixedJoint>();
        Destroy(cargo.GetComponent<FixedJoint>());
        lineHook_Bool = false;
        LineHookOf();
        cargoCapture_Bool = true;
	}
	void Update(){
		if (lineHook_Bool == true) {
			LineHook ();
		}
		if (Input.GetKeyDown (keyControllerScript.cargoCapture) && cargoCapture_Bool == true && onKey == true) {
			FixedJoint cargo =gameObject.AddComponent<FixedJoint> ();
			cargo.GetComponent<FixedJoint>().connectedBody = hookCraneR;
			imageHook.enabled = false;
			butonac.SetActive(false);
			lineHook_Bool = true;
			cargoCapture_Bool = false;
		} else if (Input.GetKeyDown (keyControllerScript.cargoCapture) && cargoCapture_Bool == false && onKey == true) {
			FixedJoint cargo = gameObject.GetComponent<FixedJoint> ();
			Destroy (cargo.GetComponent<FixedJoint> ());
			lineHook_Bool = false;
			LineHookOf ();
			cargoCapture_Bool = true;
		}
	}
	void OnTriggerEnter(Collider hook){
		if (hook.tag == "Hook") {
			imageHook.enabled = true;
			butonac.SetActive(true);
			onKey = true;
		}
	}
	void OnTriggerExit(Collider hook){
		if (hook.tag == "Hook") {
			imageHook.enabled = false;
			butonac.SetActive(false);
			onKey = false;
		}
	}

	public void LineHook(){
		pointHook.AddComponent<LineRenderer> ();
		pointHook.GetComponent<LineRenderer> ().SetWidth(0.015f,0.015f);
			
		Vector3[] lineHookCargo = new Vector3[8];
			lineHookCargo [0] = new Vector3 (pointHookCargo.position.x,pointHookCargo.position.y,pointHookCargo.position.z);
			lineHookCargo [1] = new Vector3 (pointCargo1.position.x,pointCargo1.position.y,pointCargo1.position.z);
			lineHookCargo [2] = new Vector3 (pointHookCargo.position.x,pointHookCargo.position.y,pointHookCargo.position.z);
			lineHookCargo [3] = new Vector3 (pointCargo2.position.x,pointCargo2.position.y,pointCargo2.position.z);
			lineHookCargo [4] = new Vector3 (pointHookCargo.position.x,pointHookCargo.position.y,pointHookCargo.position.z);
			lineHookCargo [5] = new Vector3 (pointCargo3.position.x,pointCargo3.position.y,pointCargo3.position.z);
			lineHookCargo [6] = new Vector3 (pointHookCargo.position.x,pointHookCargo.position.y,pointHookCargo.position.z);
			lineHookCargo [7] = new Vector3 (pointCargo4.position.x,pointCargo4.position.y,pointCargo4.position.z);
		pointHook.GetComponent<LineRenderer>().positionCount = lineHookCargo.Length;
		pointHook.GetComponent<LineRenderer>().SetPositions (lineHookCargo);
		pointHook.GetComponent<LineRenderer> ().material = matLineRen;
	}
	public void LineHookOf(){
		Destroy (pointHook.GetComponent<LineRenderer>());
	}
}

