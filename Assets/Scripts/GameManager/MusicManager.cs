using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    [Header("Audio")]
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioMixer _mixer;

    [Header("UI")]
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private float _inMasterVol = 0.5f;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private float _inMusicVol = 0.5f;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private float _inSFXVol = 1f;

    void Start()
    {
        _masterSlider.value = _inMasterVol;
        SetMasterVol(_inMasterVol);
        _musicSlider.value = _inMusicVol;
        SetMusicVol(_inMusicVol);
        _sfxSlider.value = _inSFXVol;
        SetSFXVol(_inSFXVol);

    }
    public void SetMasterVol(float value)
    {
        _mixer.SetFloat("MasterVol",Mathf.Log10(value)* 20);
    }
    public void SetMusicVol(float value)
    {
        _mixer.SetFloat("MusicVol" ,Mathf.Log10(value)* 20);
    }
    public void SetSFXVol(float value)
    {
        _mixer.SetFloat("SFXVol", Mathf.Log10(value)* 20);
    }
    public void PlayAudio(AudioClip clip)
    {
        if (clip == _source.clip)return;
        _source.Stop();
        _source.clip = clip;
        _source.Play();
    }

}