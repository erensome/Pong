using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D ballRb = other.gameObject.GetComponent<Rigidbody2D>();

        if (ballRb != null)
        {
            var normal = other.contacts[0].normal;
            ballRb.AddForce(-normal * bounceStrength);
        }
    }
}
