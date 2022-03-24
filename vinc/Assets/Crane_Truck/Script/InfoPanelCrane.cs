using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InfoPanelCrane : MonoBehaviour {

	[Header("Panel Crane")]
	public Image panelCraneIm;
	public Image panelCraneRot;
	public Image panelArrowPos1;
	public Image panelArrowPos2;
	public Image panelCraneImage;
	public Image panelCraneBot;
	//Rotation
	public float rotZ;
	public float speesRotation;
	public Text textRotation;
	//Position A
	public Text textPosition1;
	public int meterArrowPos1 = 0;
	public float arrowPos1;
	public float speesArrowPos1;
	//Position B
	public Text textPosition2;
	public int meterArrowPos2 = 0;
	public float arrowPos2;
	public float speesArrowPos2;
	public bool OnOffHoohIndicator_Bool = false;
	private bool panelCrane_Script = true;
	private bool IconPanelPrane_Bool = true;
	public Text textStartCrane;
	private bool startCraneText_Bool = true;

	void Update(){
		OnOffHoohIndicator ();
	}
	public void IndicatorCraneRot(){
		panelCraneRot.GetComponent<RectTransform> ();
		panelCraneRot.rectTransform.rotation = Quaternion.Euler (0, 0, rotZ);
		if (panelCraneRot.rectTransform.rotation.z >= 0.01f) {
			panelCraneRot.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		} else if (panelCraneRot.rectTransform.rotation.z <= -0.01f) {
			panelCraneRot.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		} else
			panelCraneRot.GetComponent<Image> ().color = new Color32 (0, 255, 2, 255);

		int textInt = (int)rotZ;
		textRotation.text = "" + textInt.ToString ();
	}
	public void IndicatorCranePos1(){
		panelArrowPos1.rectTransform.position = new Vector3 (arrowPos1,39.8f,0);
		arrowPos1 = Mathf.Clamp (arrowPos1,113.6892f,208.3227f);
		textPosition1.text = "" + meterArrowPos1.ToString ();
	}
	public void InMeter (){
		meterArrowPos1 = Mathf.Clamp (meterArrowPos1,0,1670);
		meterArrowPos2 = Mathf.Clamp (meterArrowPos2,0,1720);
		if (meterArrowPos1 == 0) {
			panelArrowPos1.GetComponent<Image> ().color = new Color32 (0,255,2,255);
		}else 
			panelArrowPos1.GetComponent<Image> ().color = new Color32 (255,255,255,255);
		if (meterArrowPos2 == 0) {
			panelArrowPos2.GetComponent<Image> ().color = new Color32 (0,255,2,255);
		}else
			panelArrowPos2.GetComponent<Image> ().color = new Color32 (255,255,255,255);
	}
	public void IndicatorCranePos2(){
		panelArrowPos2.rectTransform.position = new Vector3 (270.78f,arrowPos2,0);
		arrowPos2 = Mathf.Clamp (arrowPos2, 23.9f, 87.3f);
		textPosition2.text = "" + meterArrowPos2.ToString ();
	}
	public void OnOffHoohIndicator(){
		if (textRotation.text == "0" && textPosition1.text == "0" && textPosition2.text == "0") {
			OnOffHoohIndicator_Bool = true;
		} else
			OnOffHoohIndicator_Bool = false;
	}
	public void PanelCrane(){
		if (panelCrane_Script == true) {
			panelCraneIm.enabled = true;
			panelCraneRot.enabled = true;
			panelArrowPos1.enabled = true;
			panelArrowPos2.enabled = true;
			textRotation.enabled = true;
			textPosition1.enabled = true;
			textPosition2.enabled = true;
			textStartCrane.enabled = true;
			panelCrane_Script = false;
		} else if (panelCrane_Script == false) {
			panelCraneIm.enabled = false;
			panelCraneRot.enabled = false;
			panelArrowPos1.enabled = false;
			panelArrowPos2.enabled = false;
			textRotation.enabled = false;
			textPosition1.enabled = false;
			textPosition2.enabled = false;
			textStartCrane.enabled = false;
			panelCrane_Script = true;
		}
	}
	public void IconPanelCrane(){
		if (IconPanelPrane_Bool == true) {
			panelCraneImage.enabled = true;
			panelCraneBot.enabled = true;
			IconPanelPrane_Bool = false;
		}else if(IconPanelPrane_Bool == false){
			panelCraneImage.enabled = false;
			panelCraneBot.enabled = false;
			IconPanelPrane_Bool = true;
			}
	}
	public void StartCraneText(){
		if (startCraneText_Bool == true) {
			textStartCrane.text = "D";
			startCraneText_Bool = false;
		} else if (startCraneText_Bool == false) {
			textStartCrane.text = "P";
			startCraneText_Bool = true;
		}
	}
}

