using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider slider;

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
    }
}