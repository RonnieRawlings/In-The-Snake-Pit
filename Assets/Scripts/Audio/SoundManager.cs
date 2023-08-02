using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public Slider soundSlider;

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

    public void Start()
    {
        Play(sounds[8].name);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void SwingSound()
    {
        Play(sounds[Random.Range(0,2)].name);
        sounds[3].source.Stop();
    }

    public void SoundVolume()
    {
        sounds[0].source.volume = soundSlider.value;
        sounds[1].source.volume = soundSlider.value;
        sounds[2].source.volume = soundSlider.value;
        sounds[3].source.volume = soundSlider.value;
        sounds[4].source.volume = soundSlider.value;
        sounds[5].source.volume = soundSlider.value;
        sounds[6].source.volume = soundSlider.value;
        sounds[7].source.volume = soundSlider.value;
        sounds[8].source.volume = soundSlider.value;
        sounds[9].source.volume = soundSlider.value;
        sounds[10].source.volume = soundSlider.value;
        sounds[11].source.volume = soundSlider.value;
        sounds[12].source.volume = soundSlider.value;
        sounds[13].source.volume = soundSlider.value;
        sounds[14].source.volume = soundSlider.value;
    }
}
