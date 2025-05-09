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
    public static MixerManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
            
        else
            Destroy(gameObject);
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
        mixer.SetFloat("MasterVol", 20 * Mathf.Log10(volume));
        PlayerPrefs.SetFloat("MasterVol", 20 * Mathf.Log10(volume));
        VolumeS.MasterVolume = 20 * Mathf.Log10(volume);
    }

    public void SetSFX()
    {
        float volume = SFXSlider.value;
        mixer.SetFloat("SFXVol", 20 * Mathf.Log10(volume));
        PlayerPrefs.SetFloat("SFXVol", 20 * Mathf.Log10(volume));
        VolumeS.SFXVolume = 20 * Mathf.Log10(volume);
    }

    public void SetMusic()
    {
        float volume = MusicSlider.value;
        mixer.SetFloat("MusicVol", 20 * Mathf.Log10(volume));
        PlayerPrefs.SetFloat("MusicVol", 20 * Mathf.Log10(volume));
        VolumeS.MusicVolume = 20 * Mathf.Log10(volume);
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

public class VolumeS
{
    public static float MasterVolume = 0;
    public static float SFXVolume = 0;
    public static float MusicVolume = 0;

}