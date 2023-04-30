using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDifficulty : MonoBehaviour
{
    public void SetEasyDifficulty()
    {
        StateManager.Instance.m_enemySpeed = 25f;
        StateManager.Instance.m_bounceStrength = 3f;
        StateManager.Instance.m_launchForce = 6f;
        StateManager.Instance.isExperimentalMode = false;
        StateManager.Instance.m_scoreLimit = 3;
    }

    public void SetNormalDifficulty()
    {
        StateManager.Instance.m_enemySpeed = 50f;
        StateManager.Instance.m_bounceStrength = 4f;
        StateManager.Instance.m_launchForce = 7f;
        StateManager.Instance.isExperimentalMode = false;
        StateManager.Instance.m_scoreLimit = 3;
    }

    public void SetHardDifficulty()
    {
        StateManager.Instance.m_enemySpeed = 200f;
        StateManager.Instance.m_bounceStrength = 3f;
        StateManager.Instance.m_launchForce = 8f;
        StateManager.Instance.isExperimentalMode = false;
        StateManager.Instance.m_scoreLimit = 3;
    }

    public void SetExpDifficulty()
    {
        StateManager.Instance.m_enemySpeed = 100f;
        StateManager.Instance.m_bounceStrength = 1f;
        StateManager.Instance.m_launchForce = 8f;
        StateManager.Instance.isExperimentalMode = true;
        StateManager.Instance.m_scoreLimit = 3;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
