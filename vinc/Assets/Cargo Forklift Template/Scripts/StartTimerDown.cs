using UnityEngine;
using System.Collections;

public class StartTimerDown : MonoBehaviour {

    public static int count; //Counter need for a method activation is triggered only once

	
	void OnTriggerEnter(Collider other)
    {
        //defined the tag that is forklift platform
        if (other.gameObject.tag == "ForkPlatform")
        {
            //add to the counter
            count++;
            //if a game mode for a while, then turn on the timer
            if (PlayerPrefs.GetString("GameMode") == "TimeMode")
            {
                TimerScript.Instance.TimedMode = true;
            }
            //let me know the arrows that the target is the finish line
            arrowDirection.Instance.isFinish = true;
            //if the counter is equal to 1, then the called method of the occurrence area of the cargo
            if (count == 1)
            {
                SpawnCargoRandom.Instance.spawnFinish();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ForkPlatform")
        {
            //if the forklift platform out of the trigger off the purpose of the finish arrows
            arrowDirection.Instance.isFinish = false;

        }
    }
}
