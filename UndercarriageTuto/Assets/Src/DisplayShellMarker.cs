using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShellMarker : MonoBehaviour
{
    private Transform redArrow;
    private bool redArrowDisplay = false;

    void Start() {
        redArrow = transform.Find("red_arrow");
        redArrow.GetComponent<Renderer>().enabled = false;
    }

    void OnCollisionEnter () {
        if (!redArrowDisplay) {
        redArrow.GetComponent<Renderer>().enabled = true;
            StartCoroutine( collision() );
        }
    }
    
    private IEnumerator collision() {
        redArrowDisplay = true;
        yield return new WaitForSeconds( 0.1f );
        redArrow.GetComponent<Renderer>().enabled = false;
        redArrowDisplay = false;
    }
}
