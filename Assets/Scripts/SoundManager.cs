using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public Sound[] soundEffects;
    public AudioSource soundSource;
    public AudioSource musicSource;
    private bool isSoundOn = true;
    private bool isMusicOn = true;

    private void Awake()
    {
        isSoundOn = Convert.ToBoolean(PlayerPrefs.GetInt("Sound"));
        isMusicOn = Convert.ToBoolean(PlayerPrefs.GetInt("Music"));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        soundSource.mute = !isSoundOn;
        musicSource.mute = !isMusicOn;
    }

    public void PlaySfx(string SoundName)
    {
        Sound s = Array.Find(soundEffects, x => x.soundName == SoundName);

        if (s != null)
        {
            soundSource.PlayOneShot(s.soundEffectClip);
        }
    }
}
