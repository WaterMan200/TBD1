using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBlockHit : MonoBehaviour
{
    private bool p1Blocking = false;
    private bool p2Blocking = false;
    GameObject parentGameObject; 
    void Start()
    {
        parentGameObject = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(parentGameObject.CompareTag("P2"))
        {
            if (other.CompareTag("AttackTriggerP1L"))
                {
                    p2Blocking = true;
                }
        }
        if(parentGameObject.CompareTag("P1"))
        {
            if (other.CompareTag("AttackTriggerP2L"))
                {
                    p1Blocking = true;
                }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(parentGameObject.CompareTag("P2"))
        {
            if (other.CompareTag("AttackTriggerP1L"))
                {
                    p2Blocking = false;
                }
        }
        if(parentGameObject.CompareTag("P1"))
        {
            if (other.CompareTag("AttackTriggerP2L"))
                {
                    p1Blocking = false;
                }
        }
    }
    public bool P1Block()
    {
        return p1Blocking;
    }
    public bool P2Block()
    {
        return p2Blocking;
    }
}
