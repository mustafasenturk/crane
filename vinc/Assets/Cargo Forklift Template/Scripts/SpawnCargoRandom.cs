using UnityEngine;
using System.Collections;

public class SpawnCargoRandom : MonoBehaviour {

    public static SpawnCargoRandom Instance { get; private set; } //In the class SpawnCargoRandom describe a static property of type SpawnCargoRandom, in which to store a single instance of Manager points

    public Transform[] spawnPoints; //point which will spawn game objects

    public Transform[] cargoPrefabs; //prefabs cargo
    public Transform finishPrefabs; 

    int spawnPointIndexC; //the counter for cargo 
    int spawnPointIndexF; //the counter for finish objects 

    // Use this for initialization
    void Awake () {
        Instance = this; //initialize the Instance property an instance of a class
        spawnCargo(); //the called method spawnCargo at the start
        finishPrefabs.gameObject.SetActive(false); //hide object "Area for Cargo" at the beginning
    }



    public void spawnCargo()
    {
        //choose a random index number for the position the prefab "cargo"
        spawnPointIndexC = Random.Range(0, spawnPoints.Length); 
        //comparing numbers index the position
        //if it is the same, then again choose a random number
        if (spawnPointIndexF == spawnPointIndexC)
        {
            spawnPointIndexC = Random.Range(0, spawnPoints.Length);
        }
        
        
            int cargoIndex = Random.Range(0, cargoPrefabs.Length);//choose a random index number for the prefab "cargo"
            //create an instance of the prefab "Cargo" position "spawnPoints[spawnPointIndexC]"
            Instantiate(cargoPrefabs[cargoIndex], spawnPoints[spawnPointIndexC].position, spawnPoints[spawnPointIndexC].rotation);
        
    }

    public void spawnFinish()
    {
        if (finishPrefabs == null)
        {
            print("Please insert prefab 'targetForCargo'");
        }
        else
        {
            finishPrefabs.gameObject.SetActive(true);
        }
        //choose a random index number for the position the prefab "area for cargo"
        spawnPointIndexF = Random.Range(0, spawnPoints.Length);
        //comparing numbers index the position
        //if it is the same, then again choose a random number
        if (spawnPointIndexC == spawnPointIndexF)
            spawnPointIndexF = Random.Range(0, spawnPoints.Length);
        //move the position "area for cargo" position "spawnPoints[spawnPointIndexC]"
        finishPrefabs.transform.position = new Vector3(spawnPoints[spawnPointIndexF].position.x, spawnPoints[spawnPointIndexF].position.y, spawnPoints[spawnPointIndexF].position.z);
    }
}
