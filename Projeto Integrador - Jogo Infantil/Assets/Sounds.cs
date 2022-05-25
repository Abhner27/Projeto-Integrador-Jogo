using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sounds
{
    public string name;

    public AudioClip clip;


    [Range(0, 1)]
    public float volume = 1f;
    [Range(0.1f, 3)]
    public float pitch = 1f;
    [Range(0, 1)]
    public float spatialBlend = 0f;

    public bool loop = false;
    public bool playOnAwake= false;

    [HideInInspector]
    public AudioSource source;
}
