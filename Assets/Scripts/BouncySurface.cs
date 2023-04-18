using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private void Start()
    {
        bounceStrength = StateManager.Instance.m_bounceStrength;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D ballRb = other.gameObject.GetComponent<Rigidbody2D>();

        if (ballRb != null)
        {
            float x = ballRb.velocity.x;
            float y = -other.contacts[0].normal.y;
            Vector2 forceVector = new Vector2(x, y);
            ballRb.AddForce(forceVector * bounceStrength);
        }
    }
}
