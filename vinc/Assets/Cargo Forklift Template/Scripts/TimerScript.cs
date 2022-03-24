using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public static TimerScript Instance { get; private set; }
    public float TimerValue;
    public Text txtTimer;
    public bool TimedMode;
    public GameManager _gamemanager;

    // Use this for initialization
    void Awake () {

        Instance = this;
        if (PlayerPrefs.GetString("GameMode") != "TimeMode")
        {
            gameObject.SetActive(false);
        }
    
    }

    // Update is called once per frame
    void Update () {
        txtTimer.text = TimerValue.ToString("n2");

        if (TimedMode)
        {
            Timer();
        }

    }

    public void Timer()
    {
        TimerValue -= Time.deltaTime;
        if (TimerValue <= 0)
        {
            TimerValue = 0;
            _gamemanager.GameOver();
        }

    }
}
