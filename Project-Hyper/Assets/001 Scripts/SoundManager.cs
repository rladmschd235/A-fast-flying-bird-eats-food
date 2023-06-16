using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource btnClickSource;
    public AudioSource gameOverSource;

    private int cnt = 1;

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetbtnClickVolume(float volume)
    {
        btnClickSource.volume = volume;
        gameOverSource.volume = volume;
    }

    public void OnBGM()
    {
        musicSource.Play();
    }

    public void OnSfx()
    {
        btnClickSource.Play();
    }

    public void OnGameOver()
    {
        musicSource.Pause();
        if(cnt == 1)
        {
            gameOverSource.Play();
            cnt++;
        }
        else
        {
            return;
        }
    }
}
