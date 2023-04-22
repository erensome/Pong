using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    [HideInInspector] public float m_bounceStrength;
    [HideInInspector] public float m_enemySpeed;
    [HideInInspector] public float m_launchForce;
    [HideInInspector] public int  m_scoreLimit;
    [HideInInspector] public bool  isExperimentalMode;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
