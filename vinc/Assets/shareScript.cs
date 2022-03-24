using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shareScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Share()
    {
        new NativeShare().SetText("Install this amazing game! https://play.google.com/store/apps/details?id=" + Application.identifier).Share();
    }


}