using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public GameObject soundManager;

    public Slider musicSlider;


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
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Start()
    {
        Play(sounds[Random.Range(0, 3)].name);
        sounds[3].source.Stop();
        soundManager.GetComponent<SoundManager>().sounds[9].source.Stop();
        soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[8].name);
    }
    public void BattleTheme()
    {
        Play(sounds[Random.Range(0,3)].name);
        sounds[3].source.Stop();
        soundManager.GetComponent<SoundManager>().sounds[9].source.Stop();
        soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[8].name);
    }

    public void MusicVolume()
    {
        sounds[0].source.volume = musicSlider.value;
        sounds[1].source.volume = musicSlider.value;
        sounds[2].source.volume = musicSlider.value;
        sounds[3].source.volume = musicSlider.value;
        sounds[4].source.volume = musicSlider.value;
        sounds[5].source.volume = musicSlider.value;
    }

}
