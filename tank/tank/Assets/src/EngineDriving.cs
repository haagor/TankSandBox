using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineDriving : MonoBehaviour
{
    public AudioSource engineRun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!engineRun.isPlaying)
            {
                engineRun.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) &&
            Input.GetKeyUp(KeyCode.UpArrow) &&
            Input.GetKeyUp(KeyCode.LeftArrow) &&
            Input.GetKeyUp(KeyCode.RightArrow))
        {
            engineRun.Stop();
        }
    }
}
