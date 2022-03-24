using UnityEngine;
using System.Collections;

public class cargoFinish : MonoBehaviour {

   
    public int timeBonus = 30; //bonus for time for the successful delivery

    public float timeDown = 2f; //reverse time counter
    float timeDownConst; //reverse time counter const
    bool isCargo = false; //determining that a cargo
    bool isForklift = false; //the definition of what is a forklift

    void Start()
    {
        //assigned to the constant time
        timeDownConst = timeDown;

    }

    void Update()
    {
        //if Boolean variables are true, then the countdown begins
        if (isCargo && isForklift)
            timeDown -= Time.deltaTime;
        //if the time counter is less than or equal to 0, then the called method
        if (timeDown <= 0)
        {
            CargoHere();
        }
    }

    void OnTriggerStay(Collider other)
    {
        //If the trigger is a cargo, then turn on the Boolean variable "isCargo" to true
        if (other.gameObject.tag == "Cargo")
        {
            // gamemanager.GameWin();
            isCargo = true;
            //if Boolean variable "isForklift" the truth, then destroy the cargo
            if (isForklift)
            {
                Destroy(other.gameObject, timeDown);
                //reset the counter
                StartTimerDown.count = 0;
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        //if the trigger comes out fork-lift platform, the Boolean variable goes to true, resets the time counter. 
        //This is to ensure that once a player has started off the countdown before calling "CargoHere"
        if (other.gameObject.tag == "ForkPlatform")
        {
            isForklift = true;
            timeDown = timeDownConst;

        }
    }
    
    
    public void CargoHere()
    {
        isCargo = false; //turn off the Boolean variable "isCargo" because it is destroyed
        timeDown = 0; 
        transform.parent.gameObject.SetActive(false); //hide area for cargo
        GameManager.Instance.AddCargo();//added to counter the cargo
        //if game mode is on time, added to the time counter of bonus-time on and off the countdown.
        if (PlayerPrefs.GetString("GameMode") == "TimeMode")
        {
            TimerScript.Instance.TimerValue += timeBonus;
            TimerScript.Instance.TimedMode = false;  //If you want you can this line be removed, then the reverse counter will always be enabled, in this case, it is enabled when the forklift got the shipment
        }
        
        SpawnCargoRandom.Instance.spawnCargo(); //method to call the new cargo
        targetChangeColor.Instance.ChangeColor(); //change the color on the source
        arrowDirection.Instance.isFinish = false; //the discharged current target finish of the arrow
        timeDown = timeDownConst; // reset the time counter to the initial
    }
}
