using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ONOFFTruckCrane : MonoBehaviour {
	public KeyController keyControllerScript;

	//Start_Stop Engine
	public AudioClip startEngine;
	public AudioClip stopEngine;
	private bool startEngineIE_Bool = true;
	//Camera
	public Camera cameraCranTruck;
	public Camera camCabine;
	public CameraOrbitCar cameraOrbitCarScript;
	[Header("Truck Controller")]
	//Material
	public Material materialTruck;
	//Light
	public Light[] headlights_Truck;
	public Light[] turnIndicatorTruck;
	//Controller
	public CarControllerTruck carControllerTruck;
	//Sound Car
	public AudioSource sound_Truck;
	private bool startEngineIE_Sound_Truck = false;
	public bool startTruck_Bool = true;
	private bool onBlockTruck_Bool = true;
	public GameObject com1;
	public GameObject dop1;
	public GameObject dop2;
	public GameObject trailer2;
	private bool OnTrailer2_Bool = true;
	public Trailer trailerTruck;
	public Image trailer2Image;
	public Image iconFrame;
	private bool OnImageOnTraile2 = true;
	[Header("Crane Controller")]
	//Material
	public Material materialCrane;
	//Light
	public Light[] headlights_Crane;
	public Light[] turnIndicatorCrane;
	//Controller
	public CarControllerCrane carControllerCrane;
	//Sound Car
	public AudioSource sound_Crane;
	private bool startEngineIE_Sound_Crane = false;
	private bool startCrane_Bool = true;
	private bool onBlockCrane_Bool = true;
	private bool keyOnCrane_Bool = true;
	public CraneController craneControllerScript;
	public bool onOffCrane_Bool = true;
	private bool onCameraCabine_Bool = true;
	public bool checkOoOffCraneTruck = true;
	[Header("Panel Controller")]
	public Image headlightsImage;
	public Image turnIndicatorImage;
	[Header("Key On Light")]
	private bool keyHeadlights_Bool = true;
	private bool keyTurnIndicator_Bool = true;
	public AudioClip turnIndicatorSound;
	private bool turnIndicatorIE_Bool = true;
	private bool turnIndicatorIE_Start_Bool = false;
	public CraneController craneController;
	public InfoPanelCrane InfoPanelCraneScript;



	public void vincaktif()

    {
        craneControllerScript.onOffCrane_Bool = true;
        carControllerCrane.blockCarController = false;
        carControllerCrane.minPitch = 0.75f;
        craneController.onOffCrane_Bool = true;
        InfoPanelCraneScript.StartCraneText();
        keyOnCrane_Bool = false;
    }

    public void vinckapali()

    {
        craneControllerScript.onOffCrane_Bool = false;
        carControllerCrane.blockCarController = true;
        carControllerCrane.minPitch = 1;
        craneController.onOffCrane_Bool = false;
        InfoPanelCraneScript.StartCraneText();
        keyOnCrane_Bool = true;
    }
	void Update(){
		
		//CameraCrane
		if (Input.GetKeyDown (keyControllerScript.cameraCraneA_B) && onCameraCabine_Bool == true && onBlockTruck_Bool == true) {
			cameraCranTruck.enabled = false;
			camCabine.enabled = true;
			onCameraCabine_Bool = false;
		} else if (Input.GetKeyDown (keyControllerScript.cameraCraneA_B) && onCameraCabine_Bool == false) {
			cameraCranTruck.enabled = true;
			camCabine.enabled = false;
			onCameraCabine_Bool = true;
		}
		if (Input.GetKeyDown (keyControllerScript.headlinghts) && keyHeadlights_Bool == true) {
			HeadlightsON ();
			keyHeadlights_Bool = false;
		} else if (Input.GetKeyDown (keyControllerScript.headlinghts) && keyHeadlights_Bool == false) {
			HeadlightsOFF ();
			keyHeadlights_Bool = true;
		}
		if(Input.GetKeyDown(keyControllerScript.turning) && keyTurnIndicator_Bool == true && turnIndicatorIE_Start_Bool == true){
			StartCoroutine ("TurnIndicatorIE");
			cameraCranTruck.GetComponent<AudioSource> ().clip = turnIndicatorSound;
			cameraCranTruck.GetComponent<AudioSource> ().Play ();
			keyTurnIndicator_Bool = false;
		}else if(Input.GetKeyDown(keyControllerScript.turning) && keyTurnIndicator_Bool == false){
			StopCoroutine ("TurnIndicatorIE");
			turnIndicatorImage.GetComponent<Image> ().color = new Color32 (255,255,255,50);
			cameraCranTruck.GetComponent<AudioSource> ().Stop ();
			for(int i =0; i < turnIndicatorTruck.Length; i ++){
				turnIndicatorTruck [i].enabled = false;
			}
			for(int i =0; i < turnIndicatorCrane.Length; i++){
				turnIndicatorCrane [i].enabled = false;
			}
			keyTurnIndicator_Bool = true;
		}






        //vincin kapalı konumu

   
		//OnCrane Off Truck
		if (Input.GetKeyDown (keyControllerScript.onOffCrane) && keyOnCrane_Bool == true && startCrane_Bool == false && checkOoOffCraneTruck == true) {
			craneControllerScript.onOffCrane_Bool = true;
			carControllerCrane.blockCarController = false;
			carControllerCrane.minPitch = 0.75f;
			craneController.onOffCrane_Bool = true;
			InfoPanelCraneScript.StartCraneText ();
			keyOnCrane_Bool = false;
		} else if (Input.GetKeyDown (keyControllerScript.onOffCrane) && keyOnCrane_Bool == false && startCrane_Bool == false && checkOoOffCraneTruck == true) {
			craneControllerScript.onOffCrane_Bool = false;
			carControllerCrane.blockCarController = true;
			carControllerCrane.minPitch = 1;
			craneController.onOffCrane_Bool = false;
			InfoPanelCraneScript.StartCraneText ();
			keyOnCrane_Bool = true;
		}
	}
		//Start_Stop Engine
	IEnumerator StartEngineIE(){
		while (startEngineIE_Bool) {
			cameraCranTruck.GetComponent<AudioSource> ().PlayOneShot (startEngine,1);
			yield return new WaitForSeconds (0.5f);
			if (startEngineIE_Sound_Truck == true) {
				sound_Truck.Play ();
			}
			if (startEngineIE_Sound_Crane == true) {
				sound_Crane.Play ();
			}
			startEngineIE_Bool = false;
		}
	}
	IEnumerator TurnIndicatorIE(){
		while (true) {
			TurnIndicatorIEOn ();
			yield return new WaitForSeconds (0.35f);
		}
	}
	//Truck
	public void StartTruck(){
		if (startTruck_Bool == true && onBlockCrane_Bool == true) {
			StartCoroutine ("StartEngineIE");
			startEngineIE_Sound_Truck = true;
			onBlockTruck_Bool = false;
			carControllerTruck.GetComponent<CarControllerTruck> ().enabled = true;
			com1.GetComponent<BoxCollider> ().enabled = true;
			carControllerTruck.keyHorn_Bool = true;
			startTruck_Bool = false;
			cameraOrbitCarScript.cameraCraneTruck = true;
			turnIndicatorIE_Start_Bool = true;
		} else if (startTruck_Bool == false) {
			carControllerTruck.GetComponent<CarControllerTruck> ().enabled = false;
			startEngineIE_Sound_Truck = false;
			startEngineIE_Bool = true;
			com1.GetComponent<BoxCollider> ().enabled = false;
			sound_Truck.Stop ();
			cameraCranTruck.GetComponent<AudioSource> ().PlayOneShot (stopEngine, 1);
			onBlockTruck_Bool = true;
			carControllerTruck.keyHorn_Bool = false;
			startTruck_Bool = true;
			turnIndicatorIE_Start_Bool = false;
		}
	}
	//Crane
	public void StartCrane(){
		if (startCrane_Bool == true && onBlockTruck_Bool == true) {
			StartCoroutine ("StartEngineIE");
			startEngineIE_Sound_Crane = true;
			onBlockCrane_Bool = false;
			carControllerCrane.GetComponent<CarControllerCrane> ().enabled = true;
			carControllerCrane.keyHorn_Bool = true;
			turnIndicatorIE_Start_Bool = true;
			cameraOrbitCarScript.cameraCraneTruck = false;
			InfoPanelCraneScript.PanelCrane ();
			InfoPanelCraneScript.IconPanelCrane ();
			CheckONHook ();
			startCrane_Bool = false;
		} else if (startCrane_Bool == false) {
			carControllerCrane.GetComponent<CarControllerCrane> ().enabled = false;
			startEngineIE_Sound_Crane = false;
			startEngineIE_Bool = true;
			sound_Crane.Stop ();
			cameraCranTruck.GetComponent<AudioSource> ().PlayOneShot (stopEngine, 1);
			onBlockCrane_Bool = true;
			carControllerCrane.keyHorn_Bool = false;
			turnIndicatorIE_Start_Bool = false;
			craneController.onOffCrane_Bool = false;
			InfoPanelCraneScript.PanelCrane ();
			InfoPanelCraneScript.IconPanelCrane ();
			startCrane_Bool = true;
			}
	}
	public void HeadlightsON(){
		if (startEngineIE_Sound_Truck == true) {
			headlights_Truck [0].enabled = true;
			headlights_Truck [1].enabled = true;
			materialTruck.EnableKeyword ("_EMISSION");
			headlightsImage.GetComponent<Image> ().color = new Color32 (255,255,255,255);
		}
		if (startEngineIE_Sound_Crane == true) {
			headlights_Crane [0].enabled = true;
			headlights_Crane [1].enabled = true;
			materialCrane.EnableKeyword ("_EMISSION");
			headlightsImage.GetComponent<Image> ().color = new Color32 (255,255,255,255);
		}
	}
	public void HeadlightsOFF(){
		headlights_Truck [0].enabled = false;
		headlights_Truck [1].enabled = false;
		headlights_Crane [0].enabled = false;
		headlights_Crane [1].enabled = false;
		materialTruck.DisableKeyword ("_EMISSION");
		materialCrane.DisableKeyword ("_EMISSION");
		headlightsImage.GetComponent<Image> ().color = new Color32 (255,255,255,50);
	}
	public void TurnIndicatorIEOn(){
		
			if (turnIndicatorIE_Bool == true) {
				turnIndicatorImage.GetComponent<Image> ().color = new Color32 (255,255,255,50);
			if (startEngineIE_Sound_Truck == true) {
				for(int i =0; i < turnIndicatorTruck.Length; i ++){
					turnIndicatorTruck [i].enabled = true;
				}
			}
			if (startEngineIE_Sound_Crane == true) {
				for(int i =0; i < turnIndicatorCrane.Length; i++){
					turnIndicatorCrane [i].enabled = true;
				}

			}
			turnIndicatorIE_Bool = false;
			} else if (turnIndicatorIE_Bool == false) {
				turnIndicatorImage.GetComponent<Image> ().color = new Color32 (255,255,255,255);
			for(int i =0; i < turnIndicatorTruck.Length; i ++){
				turnIndicatorTruck [i].enabled = false;
			}
			for(int i =0; i < turnIndicatorCrane.Length; i++){
				turnIndicatorCrane [i].enabled = false;
			}
				turnIndicatorIE_Bool = true;
			}
		}
	public void OnTrailer2(){
		if (OnTrailer2_Bool == true && startTruck_Bool == false && trailerTruck.key_joinTrailer_Bool == true) {
			dop1.SetActive (false);
			dop2.SetActive (false);
			trailer2.SetActive (true);
			OnTrailer2_Bool = false;
			Debug.Log("acti");
		} else if (OnTrailer2_Bool == false) {
			dop1.SetActive (true);
			dop2.SetActive (true);
			trailer2.SetActive (false);
			OnTrailer2_Bool = true;
			Debug.Log("kapatti");
		}
	}
	public void OnImageOnTraile(){
		if (OnImageOnTraile2 == true && startTruck_Bool == false) {
			trailer2Image.enabled = true;
			iconFrame.enabled = true;
			OnImageOnTraile2 = false;
		} else if (OnImageOnTraile2 == false) {
			trailer2Image.enabled = false;
			iconFrame.enabled = false;
			OnImageOnTraile2 = true;
		}
	}





	public void CheckONHook(){
		if (craneControllerScript.onHook_Bool == false) {
			craneControllerScript.onOffCrane_Bool = true;

		}

	}
}


