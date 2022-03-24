using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
#if !UNITY_3_5
namespace MadLevelManager {
#endif
	using MadLevelManager;   

	public class win : MonoBehaviour {
		public bool completeLevel;
		public int starsCount;
		public GameObject playerkapat;
		public GameObject levelbasarili;
	
		public void home()

		{
			Application.LoadLevel("Giris");

		}
		public void ciks()

        {
			Application.Quit();

        }
        public void sayacsil()

		{
			PlayerPrefs.DeleteKey("sayi");
		}

		public void yuksek()
		{
			QualitySettings.SetQualityLevel (3);
		}

		public void orta()
		{
			QualitySettings.SetQualityLevel (2);
		}

		public void dusuk()
		{
			QualitySettings.SetQualityLevel (0);
		}

		public void tekrargame()
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		public void levelsec()

		{
			Application.LoadLevel("Level Selects");

		}

		public void reklam()

        {
			

        }
		public void rateus()
		{
			Application.OpenURL ("google.com");
		}

		public void moreoyun()
		{
			Application.OpenURL ("https://play.google.com/store/apps/developer?id=Tava+Games");
		}

		public void serbest()
		{
			Application.LoadLevel("serbest");
		}
		public void levelatla()
		{
			//playerkapat.SetActive (false);
			MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
			MadLevel.LoadLevelByName("Level Select"); // name from level configuration
		}

		void OnTriggerEnter (Collider col) {
			if(col.gameObject.tag == "win")
			{
				levelbasarili.SetActive (true);
				//	Application.LoadLevel("Success");
				//gameObject.SendMessage("ReklamAc", true);
				//MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
				//MadLevel.LoadLevelByName("Level Select"); // name from level configuration

			}

			if (col.gameObject.tag == "engel")
			{
				
			//	Time.timeScale =1;
				//AudioListener.pause = true;

			}


		
		}



		private void Execute() {
			// gain stars
			for (int i = 1; i <= starsCount; i++) { // i = 1, 2, 3...
				string starName = "star_" + i; // this is the star property name
				MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, starName, true);
			}

			// complete level
			if (completeLevel) {
				MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
			}

			// go back to level select screen
			MadLevel.LoadLevelByName("Level Select"); // name from level configuration
		}


	}
}