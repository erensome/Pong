using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraForce : Powerup
{
    private float forceStrength = 5f;
    private Rigidbody2D ballRb;
    private Animator ballAnimator;
    
    private void Start()
    {
        var ballGameObject = GameObject.Find("Ball");
        ballRb = ballGameObject.GetComponent<Rigidbody2D>();
        ballAnimator = ballGameObject.GetComponent<Animator>();
    }

    public override void Play()
    {
        var vel = ballRb.velocity;
        ballRb.AddForce(vel.normalized * forceStrength, ForceMode2D.Impulse);
        SoundManager.Instance.PlaySfx("Powerup");
        ballAnimator.Play("Force Animation");
    }
    
    public override void DestroyThis()
    {
        Destroy(gameObject);
    }
}
