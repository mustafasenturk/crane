﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class timer : MonoBehaviour
{
	
    public int timeLeft = 60; //Seconds Overall
    public Text countdown; //UI Text Object
	public GameObject finishmenu;
	public GameObject kontroller;
    void Start()
    {
		
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

    void Update()
    {
		if (timeLeft <= 0)
        {
			
            finishmenu.SetActive(true);
            kontroller.SetActive(false);
        }
		
        countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
			
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}