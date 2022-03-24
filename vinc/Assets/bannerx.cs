using UnityEngine;
using GoogleMobileAds.Api;

public class bannerx: MonoBehaviour
{

    private bool reklamDurumu = false;
    private BannerView reklamObjesi;

    void Start()
    {


        reklamObjesi = new BannerView(
            "ca-app-pub-9850849254250453/7653889460", AdSize.Banner, AdPosition.Top);
        AdRequest reklamiAl = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamiAl);
    }


    public void bannerkapat()

    {
        reklamObjesi.Hide();

    }


    public void bannerac()
    {
        reklamObjesi.Show();
    }
    void Update()
    {

    }
}