using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneBehaviour : MonoBehaviour
{
    public bool enemyZone;
    private BoxCollider2D _boxCollider2D;
    
    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    //
    public void ActivateWall()
    {
        _boxCollider2D.isTrigger = false;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void DeactivateWall()
    {
        _boxCollider2D.isTrigger = true;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
