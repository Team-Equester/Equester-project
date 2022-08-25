using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public string bgm;

    private void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audio;

            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.isloop;
        }
    }

    private void Start()
    {
        Play(bgm);
    }

    public void Play(string name)
    {
        Sound playSound = Array.Find(sounds, sound => sound.name == name);
        if (playSound == null) return;
        //playSound.audioSource.Play();
        playSound.audioSource.Play();
    }
}
