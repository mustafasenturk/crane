using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	public KeyCode cameraOnMouse;
	public KeyCode cameraCraneA_B;
	public KeyCode beepSound;
	public KeyCode handBrake;
	public KeyCode headlinghts;
	public KeyCode turning;
	[Header("Truck")]
	public KeyCode uPTruckLift;
	public KeyCode downTruckLift;
	[Header("Crane")]
	public KeyCode rotationCraneLeft;
	public KeyCode rotationCraneRight;
	public KeyCode arrowUp;
	public KeyCode arrowDown;
	public KeyCode arrowForward_A;
	public KeyCode arrowBack_B;
	public KeyCode arrow_AB;
	public KeyCode hookUp_A;
	public KeyCode hookDown_B;
	public KeyCode hook_AB;
	public KeyCode onOffHook;
	public KeyCode cargoCapture;
	public KeyCode rotationHookLeft;
	public KeyCode rotationHookRight;
	[Header("Tutning Off the Crane")]
	public KeyCode onOffCrane;
	[Header("Crane Lift (Supports)")]
	public KeyCode supportsFL_A;
	public KeyCode supportsFL_B;
	public KeyCode supportsFL_AB;
	public KeyCode supportsFR_A;
	public KeyCode supportsFR_B;
	public KeyCode supportsFR_AB;
	public KeyCode supportsBL_A;
	public KeyCode supportsBL_B;
	public KeyCode supportsBL_AB;
	public KeyCode supportsBR_A;
	public KeyCode supportsBR_B;
	public KeyCode supportsBR_AB;
	[Header("Crane Lift (Up Down)")]
	public KeyCode supportsLiftFL_A;
	public KeyCode supportsLiftFL_B;
	public KeyCode supportsLiftFL_AB;
	public KeyCode supportsLiftFR_A;
	public KeyCode supportsLiftFR_B;
	public KeyCode supportsLiftFR_AB;
	public KeyCode supportsLiftBL_A;
	public KeyCode supportsLiftBL_B;
	public KeyCode supportsLiftBL_AB;
	public KeyCode supportsLiftBR_A;
	public KeyCode supportsLiftBR_B;
	public KeyCode supportsLiftBR_AB;
	[Header("Trailer")]
	public KeyCode joinTrailer;
	public KeyCode openTrailer;
}
