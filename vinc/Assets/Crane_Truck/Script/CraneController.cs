using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CraneController : MonoBehaviour {
	public KeyController keyControllerScript;
	public ONOFFTruckCrane oNOFFTruckCraneScripr;
	public InfoPanelCrane InfoPanelCraneScript;
	public CarControllerCrane carControllerCraneScript;
	//Rotation Crane
	[Header("Rotation Crane")]
	public Transform rotationCrane;
	public float speedRotationCrane = 0;
	private Vector3 rotChek;
	public float panelRotation = 0;
	//Arrow Crane
	[Header("Arrow Crane UP DOWN")]
	public Transform arrow0;
	public float minValueArrow0;
	public float maxValueArrow0;
	public float speedArrow0;
	private Vector3 myRotationArrow0;
	public Transform pisA;
	public Transform pisB;
	//Arrow Forward
	[Header("Arrow Forward")]
	public Transform[] arrowFor;
	public Vector3 forArrow_0;
	public Vector3 backArrow_0;
	public Vector3 forArrow_1;
	public Vector3 backArrow_1;
	public Vector3 forArrow_2;
	public Vector3 backArrow_2;
	public Vector3 forArrow_3;
	public Vector3 backArrow_3;
	public float speedArrowFor = 0;
	private bool arrowFor_Bool = true;
	//Hook Crane
	[Header("Hook Crane")]
	public bool onHook_Bool = true;
	public Rigidbody arrowToHook;
	public GameObject dopCable;
	public GameObject hook;
	public Transform onHookPoint;
	public float limitHook;
	private bool stopHook = true;
	public float speedHoock;
	public HookCrane hookCraneScript;
	private bool startArrow_Bool = false;
	[Header("RackFL")]
	public Transform rackFL;
	public Vector3 uPRackFL;
	public Vector3 downRackFL;
	private bool rackFL_Bool = true;
	[Header("RackFR")]
	public Transform rackFR;
	public Vector3 uPRackFR;
	public Vector3 downRackFR;
	private bool rackFR_Bool = true;
	[Header("RackBL")]
	public Transform rackBL;
	public Vector3 uPRackBL;
	public Vector3 downRackBL;
	private bool rackBL_Bool = true;
	[Header("RackBR")]
	public Transform rackBR;
	public Vector3 uPRackBR;
	public Vector3 downRackBR;
	private bool rackBR_Bool = true;
	[Header("SupportFL")]
	public Transform supportFL;
	public Vector3 forSupportFL;
	public Vector3 backSupportFL;
	private bool supportFL_Bool = true;
	[Header("SupportFR")]
	public Transform supportFR;
	public Vector3 forSupportFR;
	public Vector3 backSupportFR;
	private bool supportFR_Bool = true;
	[Header("SupportBL")]
	public Transform supportBL;
	public Vector3 forSupportBL;
	public Vector3 backSupportBL;
	private bool supportBL_Bool = true;
	[Header("SupportBR")]
	public Transform supportBR;
	public Vector3 forSupportBR;
	public Vector3 backSupportBR;
	private bool supportBR_Bool = true;

	//Speed Rack
	public float speedRack = 0;
	//Speed Support
	public float speedSupport = 0;
	public bool onOffCrane_Bool = false;
	[Header("Cable")]
	public LineRenderer cableArrow1;
	public LineRenderer cableHook1;
	public LineRenderer cableHook2;
	public LineRenderer cableHook3;
	public LineRenderer cableHook4;
	public Transform pointCable_1A;
	public Transform pointCable_2A;
	public Transform pointHook1A;
	public Transform pointHook2A;
	public Transform pointHook1B;
	public Transform pointHook2B;
	public Transform pointHook1C;
	public Transform pointHook2C;
	public Transform pointHook1D;
	public Transform pointHook2D;
    
	void Start(){
		myRotationArrow0 = arrow0.localEulerAngles;

	}

	public void hokac()

    {
		hook.GetComponent<Rigidbody>().isKinematic = false;
        hook.AddComponent<ConfigurableJoint>();
        hook.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
        hook.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Limited;
        hook.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
        hook.GetComponent<ConfigurableJoint>().angularYMotion = ConfigurableJointMotion.Locked;
        hook.GetComponent<ConfigurableJoint>().connectedBody = arrowToHook;
        hook.GetComponent<ConfigurableJoint>().anchor = new Vector3(0, 0.62f, 0);
        hook.GetComponent<Rigidbody>().drag = 2;
        hook.AddComponent<ConstantForce>();
    }
    public void hokkapat()

    {
		Destroy(hook.GetComponent<ConfigurableJoint>());
        Destroy(hook.GetComponent<ConstantForce>());
        hook.GetComponent<Rigidbody>().isKinematic = true;
        hook.transform.position = onHookPoint.transform.position;
        hook.transform.rotation = onHookPoint.transform.rotation;
    }

	//Kol asağı yukarı sistem//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	bool kolindir = false;
	bool kolkaldir = false;
	//Kol asağı yukarı sistem

	// cabin sağ sol
	bool kabinsag = false;
	bool kabinsol = false;
	// Halat sistem

	bool halatindir = false;
	bool halatkaldir = false;
	// Halat sistem
	bool koluzat = false;
	bool kolkisalt = false;
	// Halat sistem
	bool ayaklarac = false;
	bool ayaklarkapat = false;
	//ayak genislet
	bool ayakgenislet = false;
	bool ayakdaralt = false;








    //ayakgenislet

    void ayaksistemgenislet()
	{
		
	
	supportFL.transform.localPosition = Vector3.MoveTowards(supportFL.transform.localPosition, forSupportFL, speedSupport* Time.deltaTime);
    supportFR.transform.localPosition = Vector3.MoveTowards(supportFR.transform.localPosition, forSupportFR, speedSupport* Time.deltaTime);
    supportBL.transform.localPosition = Vector3.MoveTowards(supportBL.transform.localPosition, forSupportBL, speedSupport* Time.deltaTime);
    supportBR.transform.localPosition = Vector3.MoveTowards(supportBR.transform.localPosition, forSupportBR, speedSupport* Time.deltaTime);
	}

	void ayaksistemdaralt()
    {


		supportFL.transform.localPosition = Vector3.MoveTowards(supportFL.transform.localPosition, backSupportFL, speedSupport * Time.deltaTime);
        supportFR.transform.localPosition = Vector3.MoveTowards(supportFR.transform.localPosition, backSupportFR, speedSupport * Time.deltaTime);
        supportBL.transform.localPosition = Vector3.MoveTowards(supportBL.transform.localPosition, backSupportBL, speedSupport * Time.deltaTime);
        supportBR.transform.localPosition = Vector3.MoveTowards(supportBR.transform.localPosition, backSupportBR, speedSupport * Time.deltaTime);
    }

    public void ayakgenisac()

	{
		ayakgenislet = true;	
	}


    public void ayakdaraltkapat()

	{
		ayakdaralt = true;
	}



    public void  ayakgenisacdur()
	{
		ayakgenislet = false;
	}

    public void ayakdaraltkapatdur()

	{
		ayakdaralt = false;
	}


    /// 

    void kolsistemindir()

	{
		Arron0DOWN();
        SoundPitchCraneON();
        InfoPanelCraneScript.IndicatorCranePos2();
        InfoPanelCraneScript.arrowPos2 += InfoPanelCraneScript.speesArrowPos2 * Time.deltaTime;
        InfoPanelCraneScript.InMeter();
        InfoPanelCraneScript.IndicatorCranePos2();
        InfoPanelCraneScript.meterArrowPos2++;
	}
    void kolsistemkaldir()

	{
		Arron0UP();
        SoundPitchCraneON();
        InfoPanelCraneScript.IndicatorCranePos2();
        InfoPanelCraneScript.arrowPos2 -= InfoPanelCraneScript.speesArrowPos2 * Time.deltaTime;
        InfoPanelCraneScript.InMeter();
        InfoPanelCraneScript.IndicatorCranePos2();
        InfoPanelCraneScript.meterArrowPos2--;
	}

    public void koluindir()

	{
		kolindir = true;
	}

    public void kolukaldir()

	{
		kolkaldir = true;
	}

    public void kolindirdur()

	{
		kolindir = false;
	}

	public void kolkaldirdur()

	{
		kolkaldir = false;
	}

	//////////////////////////cabin kontrolsistem////////////////////////////////////////////////////////////////////////////////////////////

    void kabinsagcalistir()

	{
		rotationCrane.Rotate(Vector3.up * speedRotationCrane * Time.deltaTime, Space.World);
        SoundPitchCraneON();
        panelRotation += Time.deltaTime;
        InfoPanelCraneScript.rotZ -= InfoPanelCraneScript.speesRotation * Time.deltaTime;
        InfoPanelCraneScript.IndicatorCraneRot();	
	}

    void kabinsolcalistir()

	{
		rotationCrane.Rotate(Vector3.up * -speedRotationCrane * Time.deltaTime, Space.World);
        SoundPitchCraneON();
        panelRotation -= Time.deltaTime;
        InfoPanelCraneScript.rotZ += InfoPanelCraneScript.speesRotation * Time.deltaTime;
        InfoPanelCraneScript.IndicatorCraneRot();
	}


    public void kabinsagac()

	{
		kabinsag = true;	
	}
    public void kabinsolac()
	{
		kabinsol = true;
	}


	public void kabinsagacdur()

    {
		kabinsag = false;
    }
    public void kabinsolacdur()
    {
		kabinsol = false;
    }

	//////////////////////////HALAT İNDİR KALDİR////////////////////////////////////////////////////////////////////////////////////////////
    void halatsistemindir()

	{
		limitHook += speedHoock * Time.deltaTime;
        hookCraneScript.UpDownHook();
        SoundPitchCraneON();
	}

    void halatsistemkaldir()
	{
		limitHook -= speedHoock * Time.deltaTime;
        hookCraneScript.UpDownHook();
        SoundPitchCraneON();
	}

    public void halatkaldirac()
	{
		halatkaldir = true;
	}

	public void halatindirac()
	{
		halatindir = true;
	}

	public void halatkaldiracdur()
    {
		halatkaldir = false;
    }

    public void halatindiracdur()
    {
		halatindir = false;
    }
	//////////////////////////kol uzat kısalt////////////////////////////////////////////////////////////////////////////////////////////
    void kolsistemuzat()

	{
		ArrowFor();
        SoundPitchCraneON();
        InfoPanelCraneScript.arrowPos1 -= InfoPanelCraneScript.speesArrowPos1 * Time.deltaTime;
        InfoPanelCraneScript.InMeter();
        InfoPanelCraneScript.IndicatorCranePos1();
        InfoPanelCraneScript.meterArrowPos1--;
        arrowFor_Bool = true;
	}

    void kolsistemkisalt()

	{
		ArrowFor();
        SoundPitchCraneON();
        InfoPanelCraneScript.arrowPos1 += InfoPanelCraneScript.speesArrowPos1 * Time.deltaTime;
        InfoPanelCraneScript.InMeter();
        InfoPanelCraneScript.IndicatorCranePos1();
        InfoPanelCraneScript.meterArrowPos1++;
        arrowFor_Bool = false;

	}

    public void koluzatac()
	{
		koluzat = true;
	}

	public void kolkisaltac()
	{
		kolkisalt = true;
	}

    public void koluzaltdur()
	{
		koluzat = false;
	}

    public void kolkisaltdur()
	{
		kolkisalt = false;
	}
	//////////////////////////ayaklar uzat kısalt////////////////////////////////////////////////////////////////////////////////////////////
    void ayaksistemac()
	{
		rackFL_Bool = true;
        RackFL();
        SoundPitchCraneON();

		rackFR_Bool = true;
        RackFR();
        SoundPitchCraneON();

		rackBL_Bool = true;
        RackBL();
        SoundPitchCraneON();

		rackBR_Bool = true;
        RackBR();
        SoundPitchCraneON();
	}

    void ayaksistemkapat()
	{
		rackFL_Bool = false;
        RackFL();
        SoundPitchCraneON();

		rackFR_Bool = false;
        RackFR();
        SoundPitchCraneON();

		rackBL_Bool = false;
        RackBL();
        SoundPitchCraneON();

		rackBR_Bool = false;
        RackBR();
        SoundPitchCraneON();

	}


    public void ayaklariactir()

	{
		ayaklarac = true;
	}
    public void ayaklarikapattir()
	{
		ayaklarkapat = true;

	}



    public void ayaklaractirdur()

	{
		ayaklarac = false;
	}

	public void ayaklarkapattirdur()
	{
		ayaklarkapat = false;
	}


	void Update(){
		if(ayakgenislet)
		{
			ayaksistemgenislet();
		}

		if(ayakdaralt)
		{
			ayaksistemdaralt();
		}



		if(ayaklarac)
		{
			ayaksistemac();
		}

		if(ayaklarkapat)
		{
			ayaksistemkapat();
		}
		if(koluzat)
		{
			kolsistemuzat();
		}

		if(kolkisalt)
		{
			kolsistemkisalt();
		}
		if(kolindir)
		{
			kolsistemindir();
		}

		if (kolkaldir)
        {
			kolsistemkaldir();
        }

		if(kabinsag)
		{
			kabinsagcalistir();
		}

		if(kabinsol)
		{
			kabinsolcalistir();
		}

		if(halatindir)
		{
			halatsistemindir();
		}

		if(halatkaldir)
		{
			halatsistemkaldir();
		}





		CheckIsKin ();
		ArrowCableLine ();
		HookCableLine1 ();
		HookCableLine2 ();
		HookCableLine3 ();
		HookCableLine4 ();
		//OnHook
		if (limitHook < -0) {
			stopHook = false;
		} else
			stopHook = true;
			//Rotation Crane
		if (Input.GetKey (keyControllerScript.rotationCraneLeft) && onOffCrane_Bool == true && startArrow_Bool == true) {
			rotationCrane.Rotate (Vector3.up * speedRotationCrane * Time.deltaTime,Space.World);
			SoundPitchCraneON ();
			panelRotation += Time.deltaTime;
			InfoPanelCraneScript.rotZ -= InfoPanelCraneScript.speesRotation * Time.deltaTime;
			InfoPanelCraneScript.IndicatorCraneRot ();
		} else if (Input.GetKey (keyControllerScript.rotationCraneRight) && onOffCrane_Bool == true && startArrow_Bool == true) {
			rotationCrane.Rotate (Vector3.up * -speedRotationCrane * Time.deltaTime,Space.World);
			SoundPitchCraneON ();
			panelRotation -= Time.deltaTime;
			InfoPanelCraneScript.rotZ += InfoPanelCraneScript.speesRotation * Time.deltaTime;
			InfoPanelCraneScript.IndicatorCraneRot ();
		}
		//Arrow0
		if (Input.GetKey (keyControllerScript.arrowUp) && onOffCrane_Bool == true && startArrow_Bool == true) {
			Arron0UP ();
			SoundPitchCraneON ();
			InfoPanelCraneScript.IndicatorCranePos2 ();
			InfoPanelCraneScript.arrowPos2 -= InfoPanelCraneScript.speesArrowPos2 * Time.deltaTime;
			InfoPanelCraneScript.InMeter ();
			InfoPanelCraneScript.IndicatorCranePos2 ();
			InfoPanelCraneScript.meterArrowPos2--;
		} else if (Input.GetKey (keyControllerScript.arrowDown) && onOffCrane_Bool == true && startArrow_Bool == true) {
			Arron0DOWN ();
			SoundPitchCraneON ();
			InfoPanelCraneScript.IndicatorCranePos2 ();
			InfoPanelCraneScript.arrowPos2 += InfoPanelCraneScript.speesArrowPos2 * Time.deltaTime;
			InfoPanelCraneScript.InMeter ();
			InfoPanelCraneScript.IndicatorCranePos2 ();
			InfoPanelCraneScript.meterArrowPos2++;
		}
		//Arrow For
		if (Input.GetKey (keyControllerScript.arrowForward_A) && Input.GetKey (keyControllerScript.arrow_AB) && onOffCrane_Bool == true && startArrow_Bool == true) {
			ArrowFor ();
			SoundPitchCraneON ();
			InfoPanelCraneScript.arrowPos1 -= InfoPanelCraneScript.speesArrowPos1 * Time.deltaTime;
			InfoPanelCraneScript.InMeter ();
			InfoPanelCraneScript.IndicatorCranePos1 ();
			InfoPanelCraneScript.meterArrowPos1--;
			arrowFor_Bool = true;
		} else if (Input.GetKey (keyControllerScript.arrowBack_B) && Input.GetKey (keyControllerScript.arrow_AB) && onOffCrane_Bool == true && startArrow_Bool == true) {
			ArrowFor ();
			SoundPitchCraneON ();
			InfoPanelCraneScript.arrowPos1 += InfoPanelCraneScript.speesArrowPos1 * Time.deltaTime;
			InfoPanelCraneScript.InMeter ();
			InfoPanelCraneScript.IndicatorCranePos1 ();
			InfoPanelCraneScript.meterArrowPos1++;
			arrowFor_Bool = false;
		}
	// Hook

             


		if (Input.GetKey (keyControllerScript.hookUp_A) && Input.GetKey (keyControllerScript.hook_AB) && onOffCrane_Bool == true && startArrow_Bool == true) {
			limitHook += speedHoock * Time.deltaTime;
			hookCraneScript.UpDownHook ();
			SoundPitchCraneON ();
		} else if (Input.GetKey (keyControllerScript.hookDown_B) && Input.GetKey (keyControllerScript.hook_AB) && onOffCrane_Bool == true && stopHook == true && startArrow_Bool == true) {
			limitHook -= speedHoock * Time.deltaTime;
			hookCraneScript.UpDownHook ();
			SoundPitchCraneON ();
		}
		// On Off Hook Crane
		if (Input.GetKeyDown (keyControllerScript.onOffHook) && onHook_Bool == true && onOffCrane_Bool == true) {
			OnOffHook ();
			dopCable.SetActive(false);
			startArrow_Bool = true;
			onHook_Bool = false;
		} else if (Input.GetKeyDown (keyControllerScript.onOffHook) && onHook_Bool == false && onOffCrane_Bool == true && InfoPanelCraneScript.OnOffHoohIndicator_Bool == true) {
			OnOffHook ();
			dopCable.SetActive(true);
			startArrow_Bool = false;
			onHook_Bool = true;
		}
		//Rack
		if (Input.GetKey (keyControllerScript.supportsFL_AB) && Input.GetKey (keyControllerScript.supportsFL_A) && onOffCrane_Bool == true) {
			rackFL_Bool = true;
			RackFL ();
			SoundPitchCraneON ();
		} else if (Input.GetKey (keyControllerScript.supportsFL_AB) && Input.GetKey (keyControllerScript.supportsFL_B) && onOffCrane_Bool == true) {
			rackFL_Bool = false;
			RackFL ();
			SoundPitchCraneON ();
		}
		if (Input.GetKey (keyControllerScript.supportsFR_AB) && Input.GetKey (keyControllerScript.supportsFR_A) && onOffCrane_Bool == true) {
			rackFR_Bool = true;
			RackFR ();
			SoundPitchCraneON ();
		} else if (Input.GetKey (keyControllerScript.supportsFR_AB) && Input.GetKey (keyControllerScript.supportsFR_B) && onOffCrane_Bool == true) {
			rackFR_Bool = false;
			RackFR ();
			SoundPitchCraneON ();
		}
		if (Input.GetKey (keyControllerScript.supportsBL_AB) && Input.GetKey (keyControllerScript.supportsBL_A) && onOffCrane_Bool == true) {
			rackBL_Bool = true;
			RackBL ();
			SoundPitchCraneON ();
		} else if (Input.GetKey (keyControllerScript.supportsBL_AB) && Input.GetKey (keyControllerScript.supportsBL_B) && onOffCrane_Bool == true) {
			rackBL_Bool = false;
			RackBL ();
			SoundPitchCraneON ();
		}
		if (Input.GetKey (keyControllerScript.supportsBR_AB) && Input.GetKey (keyControllerScript.supportsBR_A) && onOffCrane_Bool == true) {
			rackBR_Bool = true;
			RackBR ();
			SoundPitchCraneON ();
		} else if (Input.GetKey (keyControllerScript.supportsBR_AB) && Input.GetKey (keyControllerScript.supportsBR_B) && onOffCrane_Bool == true) {
			rackBR_Bool = false;
			RackBR ();
			SoundPitchCraneON ();
		}
		//Rack
		if (Input.GetKey (keyControllerScript.supportsLiftFL_AB) && Input.GetKey (keyControllerScript.supportsLiftFL_A) && onOffCrane_Bool == true) {
			SupportFL ();
			SoundPitchCraneON ();
			supportFL_Bool = true;
		} else if (Input.GetKey (keyControllerScript.supportsLiftFL_AB) && Input.GetKey (keyControllerScript.supportsLiftFL_B) && onOffCrane_Bool == true) {
			SupportFL();
			SoundPitchCraneON ();
			supportFL_Bool = false;
		}
		if (Input.GetKey (keyControllerScript.supportsLiftFR_AB) && Input.GetKey (keyControllerScript.supportsLiftFR_A) && onOffCrane_Bool == true) {
			SupportFR();
			SoundPitchCraneON ();
			supportFR_Bool = true;
		} else if (Input.GetKey (keyControllerScript.supportsLiftFR_AB) && Input.GetKey (keyControllerScript.supportsLiftFR_B) && onOffCrane_Bool == true) {
			SupportFR();
			SoundPitchCraneON ();
			supportFR_Bool = false;
		}
		if (Input.GetKey (keyControllerScript.supportsLiftBL_AB) && Input.GetKey (keyControllerScript.supportsLiftBL_A) && onOffCrane_Bool == true) {
			SupportBL();
			SoundPitchCraneON ();
			supportBL_Bool = true;
		} else if (Input.GetKey (keyControllerScript.supportsLiftBL_AB) && Input.GetKey (keyControllerScript.supportsLiftBL_B) && onOffCrane_Bool == true) {
			SupportBL();
			SoundPitchCraneON ();
			supportBL_Bool = false;
		}
		if (Input.GetKey (keyControllerScript.supportsLiftBR_AB) && Input.GetKey (keyControllerScript.supportsLiftBR_A) && onOffCrane_Bool == true) {
			SupportBR();
			SoundPitchCraneON ();
			supportBR_Bool = true;
		} else if (Input.GetKey (keyControllerScript.supportsLiftBR_AB) && Input.GetKey (keyControllerScript.supportsLiftBR_B) && onOffCrane_Bool == true) {
			SupportBR();
			SoundPitchCraneON ();
			supportBR_Bool = false;
		}
	
	}
	void LateUpdate(){
		if (pisA!=null && pisB!=null){
			pisA.LookAt(pisB.position,pisA.up);
			pisB.LookAt(pisA.position,pisB.up);
		}
	}
	// Rack
	public void RackFL(){


		if (rackFL_Bool == true) {
			rackFL.transform.localPosition = Vector3.MoveTowards (rackFL.transform.localPosition, uPRackFL, speedRack * Time.deltaTime);
		} else if (rackFL_Bool == false) {
			rackFL.transform.localPosition = Vector3.MoveTowards (rackFL.transform.localPosition, downRackFL, speedRack * Time.deltaTime);
		}
	}
		public void RackFR ()
	{
		if (rackFR_Bool == true) {
			rackFR.transform.localPosition = Vector3.MoveTowards (rackFR.transform.localPosition, uPRackFR, speedRack * Time.deltaTime);
		} else if (rackFR_Bool == false) {
			rackFR.transform.localPosition = Vector3.MoveTowards (rackFR.transform.localPosition, downRackFR, speedRack * Time.deltaTime);
		}
	}
	public void RackBL ()
	{
		if (rackBL_Bool == true) {
			rackBL.transform.localPosition = Vector3.MoveTowards (rackBL.transform.localPosition, uPRackBL, speedRack * Time.deltaTime);
		} else if (rackBL_Bool == false) {
			rackBL.transform.localPosition = Vector3.MoveTowards (rackBL.transform.localPosition, downRackBL, speedRack * Time.deltaTime);
		}
	}
	public void RackBR ()
	{
		if (rackBR_Bool == true) {
			rackBR.transform.localPosition = Vector3.MoveTowards (rackBR.transform.localPosition, uPRackBR, speedRack * Time.deltaTime);
		} else if (rackBL_Bool == false) {
			rackBR.transform.localPosition = Vector3.MoveTowards (rackBR.transform.localPosition, downRackBR, speedRack * Time.deltaTime);
		}
	}
	//Support

	public void SupportFL(){
		if (supportFL_Bool == true) {
			supportFL.transform.localPosition = Vector3.MoveTowards (supportFL.transform.localPosition, forSupportFL, speedSupport * Time.deltaTime);
		} else if (supportFL_Bool == false) {
			supportFL.transform.localPosition = Vector3.MoveTowards (supportFL.transform.localPosition, backSupportFL, speedSupport * Time.deltaTime);
		}
	}
	public void SupportFR(){
		if (supportFR_Bool == true) {
			supportFR.transform.localPosition = Vector3.MoveTowards (supportFR.transform.localPosition,forSupportFR,speedSupport * Time.deltaTime);
		} else if (supportFR_Bool == false) {
			supportFR.transform.localPosition = Vector3.MoveTowards (supportFR.transform.localPosition,backSupportFR,speedSupport * Time.deltaTime);
		}
		}
	public void SupportBL(){
		if (supportBL_Bool == true) {
			supportBL.transform.localPosition = Vector3.MoveTowards (supportBL.transform.localPosition,forSupportBL,speedSupport * Time.deltaTime);
		} else if (supportBL_Bool == false) {
			supportBL.transform.localPosition = Vector3.MoveTowards (supportBL.transform.localPosition,backSupportBL,speedSupport * Time.deltaTime);
		}
			}
	public void SupportBR(){
		if (supportBR_Bool == true) {
			supportBR.transform.localPosition = Vector3.MoveTowards (supportBR.transform.localPosition,forSupportBR,speedSupport * Time.deltaTime);
		} else if (supportBR_Bool == false) {
			supportBR.transform.localPosition = Vector3.MoveTowards (supportBR.transform.localPosition,backSupportBR,speedSupport * Time.deltaTime);
		}
	}
	public void SoundPitchCraneON(){
		carControllerCraneScript.audioSourceCar.pitch = Mathf.Lerp (carControllerCraneScript.audioSourceCar.pitch,1.89f,Time.deltaTime * 0.8f);
	}
	public void Arron0UP()
	{
		myRotationArrow0.x = Mathf.Clamp (myRotationArrow0.x + speedArrow0 * Time.deltaTime, minValueArrow0, maxValueArrow0);
		arrow0.transform.localRotation = Quaternion.Euler (myRotationArrow0);
	}
	public void Arron0DOWN()
	{
		myRotationArrow0.x = Mathf.Clamp (myRotationArrow0.x - speedArrow0 * Time.deltaTime, minValueArrow0, maxValueArrow0);
		arrow0.transform.localRotation = Quaternion.Euler (myRotationArrow0);
	}
	public void ArrowFor(){
		if (arrowFor_Bool == true) {
			arrowFor [0].transform.localPosition = Vector3.MoveTowards (arrowFor[0].transform.localPosition,forArrow_0,speedArrowFor * Time.deltaTime);
			arrowFor [1].transform.localPosition = Vector3.MoveTowards (arrowFor[1].transform.localPosition,forArrow_1,speedArrowFor * Time.deltaTime);
			arrowFor [2].transform.localPosition = Vector3.MoveTowards (arrowFor[2].transform.localPosition,forArrow_2,speedArrowFor * Time.deltaTime);
			arrowFor [3].transform.localPosition = Vector3.MoveTowards (arrowFor[3].transform.localPosition,forArrow_3,speedArrowFor * Time.deltaTime);
		} else if (arrowFor_Bool == false) {
			arrowFor [0].transform.localPosition = Vector3.MoveTowards (arrowFor[0].transform.localPosition,backArrow_0,speedArrowFor * Time.deltaTime);
			arrowFor [1].transform.localPosition = Vector3.MoveTowards (arrowFor[1].transform.localPosition,backArrow_1,speedArrowFor * Time.deltaTime);
			arrowFor [2].transform.localPosition = Vector3.MoveTowards (arrowFor[2].transform.localPosition,backArrow_2,speedArrowFor * Time.deltaTime);
			arrowFor [3].transform.localPosition = Vector3.MoveTowards (arrowFor[3].transform.localPosition,backArrow_3,speedArrowFor * Time.deltaTime);
		}
}
	public void ArrowCableLine(){
		cableArrow1.GetComponent<LineRenderer> ();
		Vector3[] posArrow = new Vector3[2];
		posArrow [0] = new Vector3 (pointCable_1A.position.x,pointCable_1A.position.y,pointCable_1A.position.z);
		posArrow [1] = new Vector3 (pointCable_2A.position.x,pointCable_2A.position.y,pointCable_2A.position.z);
		cableArrow1.positionCount = posArrow.Length;
		cableArrow1.SetPositions (posArrow);
	
	}
	public void HookCableLine1(){
		cableHook1.GetComponent<LineRenderer> ();
		Vector3[] posHook1 = new Vector3[2];
		posHook1 [0] = new Vector3 (pointHook1A.position.x,pointHook1A.position.y,pointHook1A.position.z);
		posHook1 [1] = new Vector3 (pointHook2A.position.x,pointHook2A.position.y,pointHook2A.position.z);
		cableHook1.positionCount = posHook1.Length;
		cableHook1.SetPositions (posHook1);
	}
	public void HookCableLine2(){
		cableHook2.GetComponent<LineRenderer> ();
		cableHook2.widthMultiplier = 0.017f;
		Vector3[] posHook2 = new Vector3[2];
		posHook2 [0] = new Vector3 (pointHook1B.position.x,pointHook1B.position.y,pointHook1B.position.z);
		posHook2 [1] = new Vector3 (pointHook2B.position.x,pointHook2B.position.y,pointHook2B.position.z);
		cableHook2.positionCount = posHook2.Length;
		cableHook2.SetPositions (posHook2);
	}
	public void HookCableLine3(){
		cableHook3.GetComponent<LineRenderer> ();
		Vector3[] posHook3 = new Vector3[2];
		posHook3 [0] = new Vector3 (pointHook1C.position.x,pointHook1C.position.y,pointHook1C.position.z);
		posHook3 [1] = new Vector3 (pointHook2C.position.x,pointHook2C.position.y,pointHook2C.position.z);
		cableHook3.positionCount = posHook3.Length;
		cableHook3.SetPositions (posHook3);
	}
	public void HookCableLine4(){
		cableHook4.GetComponent<LineRenderer> ();
		Vector3[] posHook4 = new Vector3[2];
		posHook4 [0] = new Vector3 (pointHook1D.position.x,pointHook1D.position.y,pointHook1D.position.z);
		posHook4 [1] = new Vector3 (pointHook2D.position.x,pointHook2D.position.y,pointHook2D.position.z);
		cableHook4.positionCount = posHook4.Length;
		cableHook4.SetPositions (posHook4);
	}
	public void OnOffHook(){
		if (onHook_Bool == true) {
			hook.GetComponent<Rigidbody> ().isKinematic = false;
			hook.AddComponent<ConfigurableJoint> ();
			hook.GetComponent<ConfigurableJoint> ().xMotion = ConfigurableJointMotion.Locked;
			hook.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Limited;
			hook.GetComponent<ConfigurableJoint> ().zMotion = ConfigurableJointMotion.Locked;
			hook.GetComponent<ConfigurableJoint> ().angularYMotion = ConfigurableJointMotion.Locked;
			hook.GetComponent<ConfigurableJoint> ().connectedBody = arrowToHook;
			hook.GetComponent<ConfigurableJoint> ().anchor = new Vector3 (0,0.62f,0);
			hook.GetComponent<Rigidbody> ().drag = 2;
			hook.AddComponent<ConstantForce> ();
		} else if (onHook_Bool == false) {
			Destroy (hook.GetComponent<ConfigurableJoint>());
			Destroy (hook.GetComponent<ConstantForce>());
			hook.GetComponent<Rigidbody> ().isKinematic = true;
			hook.transform.position = onHookPoint.transform.position;
			hook.transform.rotation = onHookPoint.transform.rotation;
		}
	}
	public void CheckIsKin(){
		if (hook.GetComponent<Rigidbody> ().isKinematic == false) {
			oNOFFTruckCraneScripr.checkOoOffCraneTruck = false;
		}else
			oNOFFTruckCraneScripr.checkOoOffCraneTruck = true;
	}

}


