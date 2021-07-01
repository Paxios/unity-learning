using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    public Slider volumeSlider;
    AudioSource audioSource;

    void Start()
    {
        volumeSlider.maxValue = 1;
        volumeSlider.minValue = 0;
        volumeSlider.value = 1;
        volumeSlider.onValueChanged.AddListener(VolumeChanged);
        audioSource = GetComponent<AudioSource>();
    }

    void VolumeChanged(float value)
    {
        audioSource.volume = value;
    }
}
