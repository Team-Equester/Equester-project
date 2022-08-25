using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audio;

    [Range(.1f,3f)]
    public float pitch;
    [Range(0f,1f)]
    public float volume;

    public bool isloop;

    [HideInInspector]
    public AudioSource audioSource;
}
