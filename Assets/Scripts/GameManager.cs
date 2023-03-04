using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;
    private int enemyScore = 0;
    private AudioSource audioSource;
    
    public Enemy enemyPaddle;
    public AudioClip scoreSfx;
    public int scoreLimit = 3;
    
    [HideInInspector]
    public bool isGameOver = false;
    [HideInInspector]
    public bool lastScorer = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void CheckGame()
    {
        if(enemyScore == scoreLimit || playerScore == scoreLimit)
        {
            GameOver(lastScorer);
        }
    }

    public void PlayerScored()
    {
        playerScore++;
        lastScorer = true;
        enemyPaddle.ResetPosition();
        audioSource.PlayOneShot(scoreSfx);
        CheckGame();
    }
    
    public void EnemyScored()
    {
        enemyScore++;
        lastScorer = false;
        enemyPaddle.ResetPosition();
        audioSource.PlayOneShot(scoreSfx);
        CheckGame();
    }
    
    public void GameOver(bool winner)
    {
        isGameOver = true;
        // if player wins then winner will be true
        if(winner)
        {
            Debug.Log("Player Kazandi");
        }
        else
        {
            Debug.Log("Enemy Kazandi");
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
