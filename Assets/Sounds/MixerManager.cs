using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    //Tomas Gomez

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private AudioSource SFXClip;

    public class VolumeS
    {
        public static float MasterVolume = 0;
        public static float SFXVolume = 0;
        public static float MusicVolume = 0;

    }
    private void Start()
    {
        LoadMusic();
        LoadSFX();
        LoadVolume();

    }

    public void SetVolume()
    {
        float volume = MasterSlider.value;
        mixer.SetFloat("MasterVol", volume);
        PlayerPrefs.SetFloat("MasterVol", volume);
        VolumeS.MasterVolume = volume;
    }

    public void SetSFX()
    {
        float volume = SFXSlider.value;
        mixer.SetFloat("SFXVol", volume);
        PlayerPrefs.SetFloat("SFXVol", volume);
        VolumeS.SFXVolume = volume;
    }

    public void SetMusic()
    {
        float volume = MusicSlider.value;
        mixer.SetFloat("MusicVol", volume);
        PlayerPrefs.SetFloat("MusicVol", volume);
        VolumeS.MusicVolume = volume;
    }

    private void LoadVolume()
    {
        MasterSlider.value = VolumeS.MasterVolume;
        SetVolume();
    }
    private void LoadSFX()
    {
        SFXSlider.value = VolumeS.SFXVolume;
        SetSFX();
    }
    private void LoadMusic()
    {
        MusicSlider.value = VolumeS.MusicVolume;
        SetMusic();
    }

    public void PlayTest()
    {
        SFXClip.Play();
    }

}
