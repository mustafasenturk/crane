using UnityEngine;
using System.Collections;

public class targetChangeColor : MonoBehaviour {

    public static targetChangeColor Instance { get; private set; }

    public Renderer[] _rend;

    private Color baseColor = Color.blue;
    private Color finishColor = Color.green;

    void Awake()
    {

        Instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cargo")
        {
            for (int i = 0; i < _rend.Length; i++)
            {
                _rend[i].material.color = finishColor;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cargo")
        {
            for (int i = 0; i < _rend.Length; i++)
            {
                _rend[i].material.color = baseColor;
            }
        }
    }

    public void ChangeColor()
    {
        for (int i = 0; i < _rend.Length; i++)
        {
            _rend[i].material.color = baseColor;
        }
    }
}
