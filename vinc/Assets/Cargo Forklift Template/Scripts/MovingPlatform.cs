using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    Mesh platformMesh;
    [SerializeField]
    Transform platform;
    [SerializeField]
    Transform startPos;
    [SerializeField]
    Transform endPos;
    [SerializeField]
    float platformSpeed;
    [SerializeField]
    float timerDown;

    bool isMoved;
    float timerDownConst;
    Vector3 direction;
    Transform destination;


    void Awake()
    {
        timerDownConst = timerDown;
        setDestination(startPos);
    }

    void FixedUpdate()
    {
        if(isMoved)
             platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);   
        
        if(Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
        {
            isMoved = false;
            timerDown -= Time.deltaTime;
            if (timerDown < 0)
            {
                setDestination(destination == startPos ? endPos : startPos);
                timerDown = timerDownConst;
                isMoved = true;
            }
        } 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireMesh(platformMesh, startPos.position, Quaternion.identity, platform.localScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireMesh(platformMesh, endPos.position, Quaternion.identity, platform.localScale);
     }

    void setDestination(Transform _destination)
    {
        destination = _destination;
        direction = (destination.position - platform.position).normalized;
    }
}
