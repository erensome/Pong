using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float xBound = 10;
    [SerializeField] private float yBound = 4;
    private Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputPos = Input.mousePosition;
        inputPos.z = mainCam.nearClipPlane;
        transform.position = mainCam.ScreenToWorldPoint(inputPos);
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
