using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    //Tomas Gomez

    [SerializeField] private AudioMixer mixer;
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider MusicSlider;
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

    public void SetVolume(float volume)
    {
        volume = MasterSlider.value;
        mixer.SetFloat("MasterVol", 20 * Mathf.Log10(volume));
        PlayerPrefs.SetFloat("MasterVol", 20 * Mathf.Log10(volume));
        VolumeS.MasterVolume = 20 * Mathf.Log10(volume);
    }

    public void SetSFX(float volume)
    {
        volume = SFXSlider.value;
        mixer.SetFloat("SFXVol", 20 * Mathf.Log10(volume));
        PlayerPrefs.SetFloat("SFXVol", 20 * Mathf.Log10(volume));
        VolumeS.SFXVolume = 20 * Mathf.Log10(volume);
    }

    public void SetMusic(float volume)
    {
        volume = MusicSlider.value;
        mixer.SetFloat("MusicVol", 20 * Mathf.Log10(volume));
        PlayerPrefs.SetFloat("MusicVol", 20 * Mathf.Log10(volume));
        VolumeS.MusicVolume = 20 * Mathf.Log10(volume);
    }

    private void LoadVolume()
    {
        SetVolume(VolumeS.MasterVolume);
    }
    private void LoadSFX()
    {
        SetSFX(VolumeS.SFXVolume);
    }
    private void LoadMusic()
    {
        SetMusic(VolumeS.MusicVolume);
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