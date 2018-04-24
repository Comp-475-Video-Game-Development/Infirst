using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = slider.value;
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 0.5f);
            PlayerPrefs.Save();
            slider.value = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = slider.value;
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        PlayerPrefs.Save();
    }
}