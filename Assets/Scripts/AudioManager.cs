using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (GameManager.instance == null)
        {
            return;
        }
        InitializeAudio();
        GameManager.instance.initializeAudio += InitializeAudio;
    }

    void InitializeAudio()
    {
        if (GameManager.instance.universeDifficulty == "<color=#11DC58>Easy</color>")
        {
            Play("Easy");
        }
        else if (GameManager.instance.universeDifficulty == "<color=#E0E0E0>Normal</color>")
        {
            Play("Normal");
        }
        else
        {
            Play("Hard");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
