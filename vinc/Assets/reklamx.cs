using UnityEngine;
using System.Collections;
using System;
using GoogleMobileAds.Api;

public class reklamx : MonoBehaviour
{
    private InterstitialAd reklamObjesi;

    void Start()
    {
        YeniReklamAl(null, null);
    }
    /*
    void OnGUI()
    {
        if( GUI.Button( new Rect( Screen.width/2 - 150, Screen.height/2 - 150, 300, 300 ), "Reklamı Göster" ) )
        {
            StartCoroutine( ReklamiGoster() );
        }
    }*/
    public void ReklamAc(bool goster)
    {
        if (goster)
        {
            Debug.Log("Çalıştı");
            StartCoroutine("ReklamiGoster");
            goster = false;
        }
    }
    IEnumerator ReklamiGoster()
    {
        while (!reklamObjesi.IsLoaded())
            yield return null;

        reklamObjesi.Show();
    }

    public void YeniReklamAl(object sender, EventArgs args)
    {
        if (reklamObjesi != null)
            reklamObjesi.Destroy();

		reklamObjesi = new InterstitialAd("ca-app-pub-9850849254250453/1999034266");
        reklamObjesi.OnAdClosed += YeniReklamAl;

        AdRequest reklamiAl = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamiAl);
    }
}