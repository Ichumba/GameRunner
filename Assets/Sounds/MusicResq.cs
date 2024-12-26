using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicResq : MonoBehaviour
{


    [Header("Audio")]
    [SerializeField] private AudioClip _cliptoPlay;

     void Start()
    {
        MusicManager.Instance.PlayAudio(_cliptoPlay);
    }
}
