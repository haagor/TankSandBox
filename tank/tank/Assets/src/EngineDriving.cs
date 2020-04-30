using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineDriving : MonoBehaviour
{
    public AudioSource engineRun;

    void Update()
    {
        if (Input.GetButton("Horizontal") ||
            Input.GetButton("Vertical"))
        {
            if (!engineRun.isPlaying)
            {
                engineRun.Play();
            }
        }

        if (!Input.GetButton("Horizontal") &&
            !Input.GetButton("Vertical"))
        {
            engineRun.Stop();
        }
    }
}
