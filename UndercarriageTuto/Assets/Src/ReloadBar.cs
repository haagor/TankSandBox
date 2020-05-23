using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxReload(int reloadLevel)
    {
        slider.maxValue = reloadLevel;
        slider.value = reloadLevel;
    }

    public void SetReloadLevel(int reloadLevel)
    {
        slider.value = reloadLevel;
    }
}
