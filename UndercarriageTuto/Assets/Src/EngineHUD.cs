using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineHUD : MonoBehaviour
{
    public Image engineOK;
    public Image engineKO;

    public void StartEngine()
    {
        engineKO.enabled = false;
        engineOK.enabled = true;
    }

    public void StopEngine()
    {
        engineOK.enabled = false;
        engineKO.enabled = true;
    }
}
