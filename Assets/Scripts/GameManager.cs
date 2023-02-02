using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;
    private int enemyScore = 0;

    public int scoreLimit = 3;

    public bool isGameOver = false;

    public int PlayerScore
    {
        get { return playerScore; }
        set 
        { 
            if(!isGameOver)
            {
                playerScore = value; 
                CheckGame();
            }
        }
    }

    public int EnemyScore
    {
        get { return enemyScore; }
        set
        { 
            if(!isGameOver)
            {
                enemyScore = value;
                CheckGame();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckGame()
    {
        if(enemyScore == scoreLimit || playerScore == scoreLimit)
        {
            isGameOver = true;
        }
        else
        {
            isGameOver = false;
        }
    }

    public void GameOver(bool winner)
    {
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
}
