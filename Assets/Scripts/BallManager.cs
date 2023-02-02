using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody2D ballRb;
    public float launchForce = 5f;
    private float launchTime = 1.5f;

    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ballRb.AddForce(GetVector() * launchForce, ForceMode2D.Impulse);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 GetVector()
    {
        Vector2[] directions = {new Vector2(1,1), new Vector2(1,-1), new Vector2(-1,1), new Vector2(-1,-1)};
        int index = Random.Range(0,directions.Length);
        return directions[index];
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        bool scorer;
        // Player scored
        if(other.gameObject.name == "Enemy Dead Zone")
        {
            scorer = true;
            GM.PlayerScore++;
            // check is game over
            if(!GM.isGameOver)
            {
                StartCoroutine(WaitAndLaunch(scorer,launchTime)); 
            }      
            else
            {
                GM.GameOver(scorer);
            }      
        }
        else if(other.gameObject.name == "Player Dead Zone")
        {
            scorer = false;
            GM.EnemyScore++;
            // Enemy scored
            if(!GM.isGameOver)
            {
                StartCoroutine(WaitAndLaunch(scorer,launchTime)); 
            }
            else
            {
                GM.GameOver(scorer);
            }          
        }
    }

    IEnumerator WaitAndLaunch(bool winner, float seconds)
    {
        ballRb.velocity = Vector2.zero;
        transform.position = winner ? new Vector2(2,0) : new Vector2(-2,0);
        yield return new WaitForSeconds(seconds);
        if (winner)
        {
            Vector2 launchDir = new Vector2(-1,1);
            ballRb.AddForce(launchDir * launchForce,ForceMode2D.Impulse);
        }
        else
        {
            Vector2 launchDir = new Vector2(1,1);
            ballRb.AddForce(launchDir * launchForce,ForceMode2D.Impulse);
        }
    }
}