using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour
{
    private bool isLaunching;
    private bool lastHit;
    private float launchTime = 1.5f;
    private Rigidbody2D ballRb;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SpawnManager spawnManager;
    public float launchForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        //launchForce = StateManager.Instance.m_launchForce;
        
        // Wait for the user to get ready.
        Invoke("StartLaunch",1f);        
    }
    
    void StartLaunch()
    {
        Vector2 launchDir = new Vector2(Random.value < 0.5f ? -1f : 1f, Random.value < 0.5f ? -1f : 1f);
        ballRb.AddForce(launchDir * launchForce, ForceMode2D.Impulse);
    }
    
    public bool GetLastHit()
    {
        return lastHit;
    }
    
    public bool GetIsLaunching()
    {
        return isLaunching;
    }
    
    IEnumerator ResetAndLaunch(bool scorer, float seconds)
    {
        isLaunching = true;
        ballRb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        yield return new WaitForSeconds(seconds);
        float y = Random.value < 0.5f ? -1 : 1;
        isLaunching = false;
        
        // true means player scored, Otherwise enemy scored.
        if (scorer)
        {
            Vector2 launchDir = new Vector2(1,y);
            ballRb.AddForce(launchDir * launchForce, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 launchDir = new Vector2(-1,y);
            ballRb.AddForce(launchDir * launchForce, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            var zone  = other.GetComponent<ZoneBehaviour>();
            
            // If enemyZone is true then Player Scored, Otherwise enemy scored.
            gameManager.Scored(zone.enemyZone);
            if (!gameManager.isGameOver)
            {
                spawnManager.DeleteAllPowerUps();
                StartCoroutine(ResetAndLaunch(gameManager.GetLastScorer(), launchTime));
            }
        }
        else if (other.gameObject.CompareTag("Powerup"))
        {
            Powerup powerUp = other.GetComponent<Powerup>();
            powerUp.Play();
            powerUp.DestroyThis();
            spawnManager.powerUpCount--;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            SoundManager.Instance.PlaySfx("Wall");
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            lastHit = true;
            SoundManager.Instance.PlaySfx("Paddle");
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            lastHit = false;
            SoundManager.Instance.PlaySfx("Paddle");
        }
        else if (other.gameObject.CompareTag("Zone"))
        {
            other.gameObject.GetComponent<ZoneBehaviour>().DeactivateWall();
            SoundManager.Instance.PlaySfx("Wall");
        }
    }
}
