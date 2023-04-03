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

    }

    public void SetNormalDifficulty()
    {
        StateManager.Instance.m_enemySpeed = 50f;
        StateManager.Instance.m_bounceStrength = 4f;
        StateManager.Instance.m_launchForce = 7f;
    }

    public void SetHardDifficulty()
    {
        StateManager.Instance.m_enemySpeed = 100f;
        StateManager.Instance.m_bounceStrength = 5f;
        StateManager.Instance.m_launchForce = 8f;
    }

    public void SetExpDifficulty()
    {
        StateManager.Instance.m_enemySpeed = 100f;
        StateManager.Instance.m_bounceStrength = 1f;
        StateManager.Instance.m_launchForce = 8f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
