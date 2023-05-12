using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    public static AudioManager instance;
    //public static float volume;

    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.volume = s.source.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
            //volume = s.volume;
        }
        
    }

    private void Start()
    {
        Play("InGameMusic");
    }

/*    public void SetVolume(float newvolume)
    {

        //volume = newvolume;
        SliderValue.SetVol.SetVola(newvolume);
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
            s.volume = s.source.volume;
        }
        
    }*/

    public void SetGameVolume(float volume)
    {
        // update volume again when slider changes
        AudioListener.volume = volume;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
            
        s.source.Play();
    }
}
