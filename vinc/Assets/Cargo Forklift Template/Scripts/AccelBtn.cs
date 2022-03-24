
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    bool accel;
    void Update()
    {
        if(accel)
        {
            NewCarController.Instance.Move(0, 1, 0, 0);
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        accel = true;
        Debug.Log(NewCarController.Instance.AccelInput);
        Debug.Log("GasDown");
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        accel = false;
       // NewCarController.Instance.Move(0, 0, 0, 0);
        Debug.Log("GasUp");
    }
}
