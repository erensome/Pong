using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject ball;
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        float yBall = ball.transform.position.y;
        Vector2 enemyPos = ball.transform.position;
        enemyPos.x= -10f;
        transform.position = Vector2.MoveTowards(transform.position,enemyPos,speed * Time.deltaTime);
        //transform.position = new Vector3(-10f,yBall,0f);
    }
}
