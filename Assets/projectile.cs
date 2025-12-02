using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pg;
    public void AssignPlayer(GameObject P)
    {
        pg = P;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(this.CompareTag("p2c"))
        {
            if(other.CompareTag("P1"))
            {
                pg.GetComponent<PlayerMove>().GotHit(0.5f);
                Destroy(gameObject);

            }
        }
        if(this.CompareTag("p1c"))
        {
            if(other.CompareTag("P2"))
            {
                pg.GetComponent<PlayerMove>().GotHit(0.5f);
                Destroy(gameObject, 0.05f);
            }
        }

    }
}
