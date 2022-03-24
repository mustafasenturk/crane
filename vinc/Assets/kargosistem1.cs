using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class kargosistem1 : MonoBehaviour
{

    public int kargosayisi;
    int sayi = 0;
    public GameObject finish;
	public GameObject arackontrol;
	public GameObject vinckontrol;






    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "win")
        {
            //levelbasarili.SetActive(true);
            //  Application.LoadLevel("Success");
            //gameObject.SendMessage("ReklamAc", true);
            //MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
            //MadLevel.LoadLevelByName("Level Select"); // name from level configuration

        }

        if (col.gameObject.tag == "Cargo")
        {
            sayi ++;
            PlayerPrefs.SetInt("sayi", sayi);
            PlayerPrefs.Save();
            Debug.Log("Kargo Bırakıldı" + sayi);
			Destroy(GetComponent<BoxCollider>());
            if (sayi >= kargosayisi)
            { 
                Debug.Log("Level Tamamlandı");
                finish.SetActive(true);
				arackontrol.SetActive(false);
				vinckontrol.SetActive(false);
            }
        }


        if (col.gameObject.tag == "kargo2")
        {
            sayi = sayi + 1;
            PlayerPrefs.SetInt("sayi", sayi);
            PlayerPrefs.Save();
            Debug.Log("Kargo Bırakıldı" + sayi);

            if (sayi >= kargosayisi)
            {
                Debug.Log("Level Tamamlandı");
                finish.SetActive(true);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteKey("sayi");
        sayi = PlayerPrefs.GetInt("sayi");
    }

    // Update is called once per frame
    void Update()
    {
        sayi = PlayerPrefs.GetInt("sayi");


    }
}
