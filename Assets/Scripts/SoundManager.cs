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
    
    public void BoundCollisionPlay()
    {
        audioSource.PlayOneShot(boundSfx);
    }

    public void PaddleCollisionPlay()
    {
        audioSource.PlayOneShot(paddleSfx);
    }

    public void PowerupPlay(Powerup powerup)
    {
        audioSource.PlayOneShot(powerup.powerupSfx);
    }
}
