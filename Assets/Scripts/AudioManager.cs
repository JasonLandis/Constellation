using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        int rand = UnityEngine.Random.Range(0, 4);
        if (rand == 0)
        {
            Play("Game1");
        }
        if (rand == 1)
        {
            Play("Game2");
        }
        if (rand == 2)
        {
            Play("Game3");
        }
        if (rand == 3)
        {
            Play("Game4");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
