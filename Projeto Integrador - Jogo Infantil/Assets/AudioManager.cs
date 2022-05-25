using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    [HideInInspector]
    public bool TocaUmaVez;  
    
    [HideInInspector]
    public bool Looping;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);



        foreach (Sounds som in sounds)
        {
            som.source = gameObject.AddComponent<AudioSource>();
            som.source.clip = som.clip;
            som.source.volume = som.volume;
            som.source.pitch = som.pitch;
            som.source.spatialBlend = som.spatialBlend;
            som.source.loop = som.loop;
            som.source.playOnAwake = som.playOnAwake;
        }

    }
    public void Start()
    {
        foreach (Sounds som in sounds)
        {
            if (som.playOnAwake == true)
            {
                PlaySound(som.name);
            }
        }
    }


    public void PlaySound(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        if (TocaUmaVez == true && Looping == false)
        {
            s.source.PlayOneShot(s.clip);
        }
        else if (Looping == true && TocaUmaVez == true)
        {
            if (s.source.isPlaying == false)
            {
                s.source.PlayOneShot(s.clip);
            }
        }
        else
        {
            s.source.Play();
        }
    }
}
