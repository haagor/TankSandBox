using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public AudioSource engineSound;
    public ParticleSystem engineSmoke;
    private bool engineOn = false;

    public bool IsEngineOn()
    {
        return engineOn;
    }

    public void CheckActionEngine(EngineHUD engineHUD)
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!engineOn)
            {
                engineOn = true;
                engineSound.Play();
                engineSmoke.Play();
                engineHUD.StartEngine();
            }
            else
            {
                engineOn = false;
                engineSound.Stop();
                engineSmoke.Stop();
                engineHUD.StopEngine();
            }
        }
    }
}
