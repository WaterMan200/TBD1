using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Only GameObjects with a Rigidbody can be assigned as the projectile.
    public GameObject circle;
    // Speed of the projectile when fired.
    // This is a public variable so it can be adjusted in the Unity Editor.
    // Update is called once per frame
    // This method checks for input and fires a projectile if the attack action is pressed.
    public void Shoot(Transform pos, int rotation, GameObject player)
    {
        // Check if the "Attack" action was pressed this frame
        // If it was, instantiate a projectile at the player's position and set its velocity.
        GameObject p = Instantiate(circle, new Vector2(pos.position.x, pos.position.y - 1), Quaternion.Euler(0, 0, 0));
        if(pos.eulerAngles.y == 0+rotation)
        {
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
        }
        else
        {
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);    
        }

        if(player.GetComponent<PlayerMove>().playerIndex == 0)
        {
            p.tag = "p2c";
        }
        else if(player.GetComponent<PlayerMove>().playerIndex == 1)
        {
            p.tag = "p1c";
        }
        p.GetComponent<projectile>().AssignPlayer(player);
        
    }

}

