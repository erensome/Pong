using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Powerup
{
    private Enemy enemy;
    private Coroutine cor;
    private float freezeTime = 1f;
    private bool hasStarted; // False by default. Prevent powerup overlapping.
    private Animator enemyAnimator;
    private void Awake()
    {
        var enemyGameObject = GameObject.Find("Enemy");
        enemy = enemyGameObject.GetComponent<Enemy>();
        enemyAnimator = enemyGameObject.GetComponent<Animator>();
    }
    
    public override void Play()
    {
        if (!hasStarted)
        {
            cor = StartCoroutine(FreezePower());
            hasStarted = true;
        }
        else
        {
            StopCoroutine(cor);
            cor = StartCoroutine(FreezePower());
        }
    }

    public override void DestroyThis()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject,freezeTime + .1f);
    }

    private IEnumerator FreezePower()
    {
        soundManager.PlayPowerup(this);
        enemy.enabled = false;
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        enemyAnimator.Play("Freeze Animation");
        yield return new WaitForSeconds(freezeTime);
        enemy.enabled = true;
        hasStarted = false;
    }
}
