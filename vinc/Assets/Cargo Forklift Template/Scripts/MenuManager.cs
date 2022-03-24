using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {

    public Animator MenuPanel;

    public Text txtGraphics;


    public Toggle chkSoundT;
    public Toggle chkMusicT;


    // Use this for initialization
    void Start () {

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

        txtGraphics.text = GetQualityName(QualitySettings.GetQualityLevel());

    }


    //Save the game mode, and the scene loads
    public void SwitchToSelection(string GameMode)
    {
        PlayerPrefs.SetString("GameMode", GameMode);
        SceneManager.LoadScene(1);
    }

    //Start the animation GameMode panel
    public void PlayGame_btn()
    {
        MenuPanel.SetBool("Play", true);
    }

    //Start the animation Settings panel
    public void Settings_btn()
    {
        MenuPanel.SetBool("Settings", true);
    }

    //Start the animation return to the previous panel
    public void Back_btn(string back)
    {
        MenuPanel.SetBool(back, false);
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

    //Selection of quality graphics
    public void ChangeGraphics(string GraphicsSet)
    {
        if (GraphicsSet == "up")
        {
            QualitySettings.IncreaseLevel();
        }
        else if (GraphicsSet == "down")
        {
            QualitySettings.DecreaseLevel();
        }
        txtGraphics.text = GetQualityName(QualitySettings.GetQualityLevel());
    }

    public string GetQualityName(int qualityNo)
    {
        string[] names;
        names = QualitySettings.names;

        return names[qualityNo];
    }
}
