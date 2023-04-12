using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip scoreSfx;
    [SerializeField]
    private AudioClip boundSfx;
    [SerializeField]
    private AudioClip paddleSfx;
        
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayBound()
    {
        audioSource.PlayOneShot(boundSfx);
    }

    public void PlayPaddle()
    {
        audioSource.PlayOneShot(paddleSfx);
    }

    public void PlayPowerup(Powerup powerup)
    {
        audioSource.PlayOneShot(powerup.powerupSfx);
    }

    public void PlayScore()
    {
        audioSource.PlayOneShot(scoreSfx);
    }
}
