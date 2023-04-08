using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip boundCollSfx;
    [SerializeField] private AudioClip paddleCollSfx;
    public PlayerController playerPaddle;
    public Enemy enemyPaddle;
    public AudioClip scoreSfx;
    public GameObject gameOverElements;
    public Text gameOverText;
    public Text playerScoreText;
    public Text enemyScoreText;
    public int scoreLimit = 3;
    [HideInInspector] public bool isGameOver;
    
    private bool lastScorer;
    private int playerScore = 0;
    private int enemyScore = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public bool GetLastScorer()
    {
        return lastScorer;
    }

    public void Scored(bool scorer)
    {
        if (scorer)
        {
            playerScore++;
            lastScorer = true;
            playerScoreText.text = $"{playerScore}";
        }
        else
        {
            enemyScore++;
            lastScorer = false;
            enemyScoreText.text = $"{enemyScore}";
        }
        enemyPaddle.ResetPosition();
        ResetZones();
        CheckGame();
    }

    private void ResetZones()
    {
        var zones = FindObjectsOfType<ZoneBehaviour>();
        foreach (var zone in zones)
        {
            zone.DeactivateWall();
        }
    }
    
    private void CheckGame()
    {
        if(enemyScore == scoreLimit || playerScore == scoreLimit)
        {
            GameOver(lastScorer);
        }
    }
    
    private void GameOver(bool winner)
    {
        isGameOver = true;
        playerPaddle.enabled = false;
        gameOverElements.SetActive(true);
        Destroy(enemyPaddle);
        
        // if player wins then winner will be true
        if(winner)
        {
            gameOverText.text = $"You Win!";
        }
        else
        {
            gameOverText.text = $"You Lost!";
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
