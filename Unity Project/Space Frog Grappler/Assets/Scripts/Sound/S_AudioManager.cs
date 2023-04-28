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
    public AudioClip oxygenBeep;

    public float randomChoice = 0;

    //Creates an audiomanager instance and and audiosurce
    public AudioSource source;
    public AudioSource croakSource;
    public AudioSource chompSource;
    public AudioSource bonkSource;
    public AudioSource oxygenSource;
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

        //Each one of these is an individual sound effect player. When you call one of these functions you can play its respective sound effect.

    public void ChompSFX()
    {
        if (instance != null)
        {
            if (instance.chompSource != null)
            {
                instance.chompSource.Stop();
                instance.chompSource.clip = instance.Chomp;
                instance.chompSource.Play();
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
                source.pitch = 1.0f;
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
                source.pitch = 1.0f;
            }
        }
    }

    public void BonkSFX()
    {
        if (instance != null)
        {
            if (instance.bonkSource != null)
            {
                instance.bonkSource.Stop();
                instance.bonkSource.clip = instance.Bonk;
                instance.bonkSource.Play();
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
            if (instance.croakSource != null)
            {
                if (GameObject.FindWithTag("FrogIsHere"))
                {
                    instance.croakSource.Stop();
                    instance.croakSource.clip = instance.Croak;
                    instance.croakSource.Play();
                }
            }
        }
    }

    public void OxygenBeepSFX()
    {
        if (instance != null)
        {
            if (instance.oxygenSource != null)
            {
                instance.oxygenSource.Stop();
                instance.oxygenSource.clip = instance.oxygenBeep;
                source.pitch = 1.0f;
                instance.oxygenSource.Play();
            }
        }
    }
}
