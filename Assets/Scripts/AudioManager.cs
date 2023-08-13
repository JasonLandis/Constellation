using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject soundOff;

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
            Play("Menu");
        }
        else
        {
            Play("Game");
        }
        IsSoundOn();
    }

    private void IsSoundOn()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            SoundOn();
        }
        else
        {
            SoundOff();
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void SoundOn()
    {
        AudioListener.volume = 1;
        soundOff.SetActive(false);
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void SoundOff()
    {
        AudioListener.volume = 0;
        soundOff.SetActive(true);
        PlayerPrefs.SetInt("Sound", 0);
    }
}
