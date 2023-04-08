using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public AudioClip powerupSfx;
    protected SoundManager soundManager;
    private void Awake()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }
    public abstract void Play();
    public abstract void DestroyThis();
}
