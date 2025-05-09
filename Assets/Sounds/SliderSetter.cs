using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using OpenCover.Framework.Model;
using static PlayerFPS;

public class SliderSetter : MonoBehaviour
{
    [SerializeField] private int _sliderType;
    [SerializeField] private Slider _me;
    public delegate void _method(float lol);
    static public event _method _changeValue;

    void Start()
    {
        switch (_sliderType)
        {
            case 1: 
                MixerManager.Instance.MasterSlider = _me;
                _changeValue += MixerManager.Instance.SetVolume;
                _me.value = VolumeS.MasterVolume;
                break;
            case 2:
                MixerManager.Instance.MusicSlider = _me;
                _changeValue += MixerManager.Instance.SetMusic;
                _me.value = VolumeS.MusicVolume;
                break;
            case 3: 
                MixerManager.Instance.SFXSlider = _me;
                _me.value = VolumeS.SFXVolume;
                _changeValue += MixerManager.Instance.SetSFX;
                break;
        }

        _me.onValueChanged.AddListener(delegate { _changeValue(_me.value); });
    }


}
