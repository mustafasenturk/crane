using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class counters : MonoBehaviour {

	public float waitTime = 1f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            print("Timer is done");
            timer = 0f;
        }
    }
}
