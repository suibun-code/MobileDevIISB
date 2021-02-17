using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeScript : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource AudioManager;
    public AudioMixer mixer;

    float volumeSliderValue;

    void Update()
    {
        OnVolumeSliderChanged();
    }

    //public void VolumeController()
    //{
    //    //volumeSlider.value = volumeAudio.volume;
    //    volumeAudio.volume = volumeSlider.value;
    //}

    public void OnVolumeSliderChanged()
    {
        AudioManager.volume = volumeSlider.value;
    }
    //public Slider slider;
    //public AudioMixer mixer;
    //public string MasterVolume;

    
    //private void Awake()
    //{
    //    float savedVol = PlayerPrefs.GetFloat(MasterVolume, slider.maxValue);

    //    SetVolume(savedVol);
    //    slider.value = savedVol;
    //    slider.onValueChanged.AddListener((float Volume) => SetVolume(Volume));
    //}
    //public void SetVolume(float SliderValue)
    //{
    //    mixer.SetFloat(MasterVolume, Mathf.Log10(SliderValue) * 20);
    //}

    //public float ConvertToDecibal(float SliderValue)
    //{
    //   return Mathf.Log10(SliderValue) * 20;
    //}
}
