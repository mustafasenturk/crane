using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class kargosistem : MonoBehaviour {

	public int kargosayisi;
	int sayi =0;
	public GameObject finish;
	public GameObject gorev;
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
		if (col.gameObject.tag == "gorevtamam")
        {
            sayi = sayi + 1;
            PlayerPrefs.SetInt("sayi", sayi);
            PlayerPrefs.Save();
            Debug.Log("Kargo Bırakıldı" + sayi);
            Destroy(col.gameObject);
            if (sayi >= kargosayisi)
            {
                Debug.Log("Level Tamamlandı");
                finish.SetActive(true);
            }
        }


        if (col.gameObject.tag == "kargo")
        {
			sayi = sayi + 1;
			PlayerPrefs.SetInt("sayi", sayi);
			PlayerPrefs.Save();
			Debug.Log("Kargo Bırakıldı" + sayi);
			Destroy(col.gameObject);
			if(sayi >= kargosayisi)
			{
				Debug.Log("Level Tamamlandı");
				finish.SetActive(true);
			}
        }
		if (col.gameObject.tag == "kargoyoket")
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

		if (col.gameObject.tag == "gorevli")
        {
            sayi = sayi + 1;
            PlayerPrefs.SetInt("sayi", sayi);
            PlayerPrefs.Save();
            Debug.Log("Kargo Bırakıldı" + sayi);

            if (sayi >= kargosayisi)
            {
				Destroy(col.gameObject);
                Debug.Log("Level Tamamlandı");
				gorev.SetActive(true);
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
	void Start () {
		PlayerPrefs.DeleteKey("sayi");
		//	sayi= PlayerPrefs.GetInt("sayi");
		sayi = 0;
	}

	// Update is called once per frame
	void Update()
	{
		sayi = PlayerPrefs.GetInt("sayi");
        
            
	}
}
