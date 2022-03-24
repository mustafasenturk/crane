using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public GameObject panelGameOver;
    public Text txtCollected;
    public Text txtMoney;
    public Text cargo;
    public int moneyForOneCargo = 10;
    int CollectedStars;
    int CollectedCargo;
    public Toggle chkSoundT;
    public Toggle chkMusicT;

    // Use this for initialization
    void Awake () {

        Instance = this;
        chkSoundT.onValueChanged.AddListener(ToggleSound);
        chkMusicT.onValueChanged.AddListener(ToggleMusic);

        if (PlayerPrefs.GetString("chkSounds", "true") == "true")
        {
            //GetComponent<AudioSource>().mute = false;
            chkSoundT.isOn = true;

        }
        else if (PlayerPrefs.GetString("chkSounds", "false") == "false")
        {
            // GetComponent<AudioSource>().mute = true;
            chkSoundT.isOn = false;

        }

        if (PlayerPrefs.GetString("chkMusic", "true") == "true")
        {
            //GetComponent<AudioSource>().mute = false;
            chkMusicT.isOn = true;

        }
        else if (PlayerPrefs.GetString("chkMusic", "false") == "false")
        {
            // GetComponent<AudioSource>().mute = true;
            chkMusicT.isOn = false;

        }
        Time.timeScale = 1;

    }
	

    public void AddStar()
    {
       // CollectedStars += 1;
    }

    public void AddCargo()
    {
        CollectedCargo += 1;
        cargo.text = CollectedCargo.ToString();
    }

    public void GameWin ()
    {
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        txtCollected.text = CollectedCargo.ToString();
        txtMoney.text ="" + CollectedCargo * moneyForOneCargo;
        panelGameOver.SetActive(true);
        Time.timeScale = 0;

    }

//UI
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //Turning on and off sound
    public void ToggleSound(bool chkSound)
    {
        //chkSound = PlayerPrefs.GetString("chkSettings", "true") == "true";

        if (!chkSound)
        {
            PlayerPrefs.SetString("chkSounds", chkSound ? "true" : "false");
            //audio.mute = true;
            // AudioListener.pause = true;
        }
        else if (chkSound)
        {
            PlayerPrefs.SetString("chkSounds", chkSound ? "true" : "false");
            //audio.mute = false;
            // AudioListener.pause = false;
        }
    }

    //Turning on and off music
    public void ToggleMusic(bool chkMusic)
    {
        //chkSound = PlayerPrefs.GetString("chkSettings", "true") == "true";

        if (!chkMusic)
        {
            PlayerPrefs.SetString("chkMusic", chkMusic ? "true" : "false");
            //audio.mute = true;
            // AudioListener.pause = true;
        }
        else if (chkMusic)
        {
            PlayerPrefs.SetString("chkMusic", chkMusic ? "true" : "false");
            //audio.mute = false;
            // AudioListener.pause = false;
        }
    }


   
}
