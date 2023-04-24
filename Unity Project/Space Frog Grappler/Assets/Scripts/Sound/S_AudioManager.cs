using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class S_AudioManager : MonoBehaviour
{
    //These clips each hold one sound effect that can be called via a function.
    public AudioClip Chomp;
    public AudioClip TongueLaunch;
    public AudioClip TongueHit;
    public AudioClip TongueRetract;
    public AudioClip Bonk;
    public AudioClip menuHover;
    public AudioClip menuClick;
    public AudioClip Croak;

    public float randomChoice = 0;

    //Creates an audiomanager instance and and audiosurce
    public AudioSource source;
    private static S_AudioManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }

        randomChoice = UnityEngine.Random.Range(0.8f, 1.2f);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        source = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }

        //Each one of these is an individual sound effect player. When you call one of these functions you can play its respective sound effect.

        public void ChompSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.Chomp;
                source.pitch = 1.0f;
                instance.source.Play();
            }
        }
    }

    public void TongueLaunchSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                randomChoice = UnityEngine.Random.Range(0.8f, 1.2f);

                instance.source.Stop();
                instance.source.clip = instance.TongueLaunch;
                source.pitch = randomChoice;
                instance.source.Play();
            }
        }
    }

    public void TongueHitSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.TongueHit;
                source.pitch = 1.0f;
                instance.source.Play();
            }
        }
    }

    public void TongueRetractSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                randomChoice = UnityEngine.Random.Range(0.8f, 1.2f);

                instance.source.Stop();
                instance.source.clip = instance.TongueRetract;
                source.pitch = randomChoice;
                instance.source.Play();
            }
        }
    }

    public void BonkSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.Bonk;
                source.pitch = 1.0f;
                instance.source.Play();
            }
        }
    }

    public void HoverSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuHover;
                source.pitch = 1.0f;
                instance.source.Play();
            }
        }
    }

    public void ClickSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuClick;
                source.pitch = 1.0f;
                instance.source.Play();
            }
        }
    }

    public void CroakSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.Croak;
                source.pitch = 1.0f;
                instance.source.Play();
            }
        }
    }
}
