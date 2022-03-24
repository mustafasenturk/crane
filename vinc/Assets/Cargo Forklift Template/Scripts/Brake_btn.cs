using UnityEngine.EventSystems;

using UnityEngine;

public class Brake_btn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool brake;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (brake)
        {
            NewCarController.Instance.Move(0, 0, -1, 0);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        brake = true;
        Debug.Log("brake");

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        brake = false;
    }
}
