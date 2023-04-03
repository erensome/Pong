using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Rigidbody2D enemyRb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        enemyRb = GetComponent<Rigidbody2D>();
        //speed = StateManager.Instance.m_enemySpeed;
    }

    private void FixedUpdate()
    {
        if (ballRb.velocity.x < 0.0f)
        {
            if (ballRb.position.y > transform.position.y)
            {
                enemyRb.AddForce(Vector2.up * speed);
            }
            else if (ballRb.position.y < transform.position.y)
            {
                enemyRb.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            if(transform.position.y > 0.0f) enemyRb.AddForce(Vector2.down * speed);
            else if(transform.position.y < 0.0f) enemyRb.AddForce(Vector2.up * speed);
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(-10f, 0f);
        enemyRb.velocity = Vector2.zero;
    }
}
