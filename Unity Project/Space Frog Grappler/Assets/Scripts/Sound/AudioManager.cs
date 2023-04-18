using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //These clips each hold one sound effect that can be called via a function.
    public AudioClip Chomp;
    public AudioClip TongueLaunch;
    public AudioClip TongueHit;
    public AudioClip TongueRetract;
    public AudioClip Bonk;
    public AudioClip menuHover;
    public AudioClip menuClick;

    public float randomChoice = 0;

    //Creates an audiomanager instance and and audiosurce
    private AudioSource source;
    private static AudioManager instance;

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

        randomChoice = UnityEngine.Random.Range(0, 2);
    }

    public void Start()
    {
        //Finds the audiomanager
        source = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    //Each one of these is an individual sound effect player. When you call one of these functions you can play its respective sound effect.

    public void ChompSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                if (source.clip != Chomp)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.Chomp;
                    instance.source.Play();
                }
            }
        }
    }

    public void TongueLaunchSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                if (source.clip != TongueLaunch)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.TongueLaunch;
                    source.pitch = randomChoice;
                    instance.source.Play();

                    source.pitch = 0;

                    randomChoice = UnityEngine.Random.Range(0, 2);
                }
            }
        }
    }

    public void TongueHitSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                if (source.clip != TongueHit)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.TongueHit;
                    instance.source.Play();
                }
            }
        }
    }

    public void TongueRetractSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                if (source.clip != TongueRetract)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.TongueRetract;
                    source.pitch = randomChoice;
                    instance.source.Play();

                    source.pitch = 0;

                    randomChoice = UnityEngine.Random.Range(0, 2);
                }
            }
        }
    }

    public void BonkSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                if (source.clip != Bonk)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.Bonk;
                    instance.source.Play();
                }
            }
        }
    }

    public void HoverSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                if (source.clip != menuHover)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.menuHover;
                    instance.source.Play();
                }
            }
        }
    }

    public void ClickSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                if (source.clip != menuClick)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.menuClick;
                    instance.source.Play();
                }
            }
        }
    }
}
