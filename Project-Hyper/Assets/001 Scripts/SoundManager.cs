using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource btnClickSource;

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetbtnClickVolume(float volume)
    {
        btnClickSource.volume = volume;
    }

    public void OnBGM()
    {
        musicSource.Play();
    }

    public void OnSfx()
    {
        btnClickSource.Play();
    }
}
