using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpedFork : MonoBehaviour {

    [SerializeField]
    Mesh platformMesh;
    [SerializeField]
    Transform fork;
    [SerializeField]
    Transform mast;
    [SerializeField]
    Transform startPos;
    [SerializeField]
    Transform endPos;
    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireMesh(platformMesh, startPos.position, Quaternion.identity, fork.localScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireMesh(platformMesh, endPos.position, Quaternion.identity, fork.localScale);
    }

}
