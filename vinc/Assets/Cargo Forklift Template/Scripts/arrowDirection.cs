using UnityEngine;
using System.Collections;

public class arrowDirection : MonoBehaviour {

    public static arrowDirection Instance { get; private set; }
    public bool isFinish = false;
    public Transform target;
	// Use this for initialization
	void Awake () {

        Instance = this;

	}
	
	// Update is called once per frame
	void Update () {
        if (isFinish)
        {
            if (target != null)
            {
                target = GameObject.FindWithTag("Finish").transform;
            }
        }
        else
        {
            if (target != null)
            {
                target = GameObject.FindWithTag("Cargo").transform;
            }
        }
        transform.LookAt(target);

    }
}
