using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    private bool p1Hitting = false;
    private bool p2Hitting = false;
    GameObject parentGameObject; 
    void Start()
    {
        parentGameObject = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(parentGameObject.CompareTag("P2"))
        {
            if(other.CompareTag("P1"))
            {
                p2Hitting = true;
            }
        }
        if(parentGameObject.CompareTag("P1"))
        {
            if(other.CompareTag("P2"))
            {
                p1Hitting = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(parentGameObject.CompareTag("P2"))
        {
            if (other.CompareTag("P1"))
            {
                p2Hitting = false;
            }
        }
        if(parentGameObject.CompareTag("P1"))
        {
            if(other.CompareTag("P2"))
            {
                p1Hitting = false;
            }
        }
    }
    public bool P1Hit()
    {
        return p1Hitting;
    }
    public bool P2Hit()
    {
        return p2Hitting;
    }
}
