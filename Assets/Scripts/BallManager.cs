using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour
{
    public float launchForce = 5f;
    private float launchTime = 1.5f;

    private GameManager GM;
    private Rigidbody2D ballRb;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Vector2 launchDir = GetVector();
        ballRb.AddForce(launchDir * launchForce, ForceMode2D.Impulse);        
    }
    
    Vector2 GetVector()
    {
        var x = Random.value < 0.5f ? -1f : 1f;
        var y = Random.value < 0.5f ? -1f : 1f;
        return new Vector2(x, y);
    }
    
    IEnumerator ResetAndLaunch(bool scorer, float seconds)
    {
        ballRb.velocity = Vector2.zero;
        transform.position = scorer ? new Vector2(2,0) : new Vector2(-2,0);
        yield return new WaitForSeconds(seconds);
        float y = Random.value < 0.5f ? -1 : 1;
        
        // true means player scored, Otherwise enemy scored.
        if (scorer)
        {
            Vector2 launchDir = new Vector2(-1,y);
            ballRb.AddForce(launchDir * launchForce, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 launchDir = new Vector2(1,y);
            ballRb.AddForce(launchDir * launchForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy Dead Zone")) 
        {
            // Player Score
            GM.PlayerScored();
        }
        else if (other.gameObject.CompareTag("Player Dead Zone"))
        {
            // Enemy Score
            GM.EnemyScored();
        }
        
        if (!GM.isGameOver)
        {
            StartCoroutine(ResetAndLaunch(GM.lastScorer, launchTime));
        }
    }
}