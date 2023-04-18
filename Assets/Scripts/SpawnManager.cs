using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager GM;
    public BallManager BM;
    public int powerUpCount = 0;
    public GameObject[] powerupPrefabs;

    [SerializeField] private int powerUpLimit;
    private float xBound = 6f;
    private float yBound = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        // If not selected experimental mode then just deactivate the spawn manager and return.
        if (!StateManager.Instance.isExperimentalMode)
        {
            gameObject.SetActive(false);
            return;
        }
        InvokeRepeating("CheckSpawn",3f,5f);
    }
    
    public void DeleteAllPowerUps()
    {
        var powerUps = GameObject.FindObjectsOfType<Powerup>();
        powerUpCount = 0;
        foreach (var powerUp in powerUps)
        {
            powerUp.DestroyThis();
        }
    }
    
    void CheckSpawn()
    {
        var powerUps = GameObject.FindGameObjectsWithTag("Powerup");
        int count = powerUps.Length;
        if (count < powerUpLimit && !GM.isGameOver && !BM.GetIsLaunching())
        {
            SpawnPowerup();
        } 
    }

    void SpawnPowerup()
    {
        int index = Random.Range(0, powerupPrefabs.Length);
        var spawnPos = new Vector2(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound));
        Instantiate(powerupPrefabs[index], spawnPos, Quaternion.identity);
        powerUpCount++;
    }
}
