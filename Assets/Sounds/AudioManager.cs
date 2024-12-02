using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer audioMix;
    public List<AudioClip> clips;
    public AudioSource source;
    private void Awake()
    {
     source = GetComponent<AudioSource>();   
    }

    public void playSound(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < clips.Count)
        {
            
        }
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
