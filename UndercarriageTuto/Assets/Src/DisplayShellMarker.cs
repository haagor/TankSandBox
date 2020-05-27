using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShellMarker : MonoBehaviour
{
    private Transform redArrow;

    void Start() {
        Debug.Log("Y A QUELQU UN?");
        redArrow = transform.Find("red_arrow");
        redArrow.GetComponent<Renderer>().enabled = false;
    }

    void OnCollisionEnter ()
    {
        Debug.Log("ça collisionne");
        redArrow.GetComponent<Renderer>().enabled = true;
    }
}
