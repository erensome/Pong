using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xBound = 10;
    private float yBound = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputPos = Input.mousePosition;
        inputPos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(inputPos);
        if (transform.position.x != xBound)
        {
            transform.position = new Vector2(xBound, transform.position.y);
        }
        if (transform.position.y > yBound || transform.position.y < -yBound)
        {
            transform.position = new Vector2(transform.position.x, yBound * Mathf.Sign(transform.position.y));
        }
        
    }
}
