using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour, IUsable
{

    private PlayerMovement player;
    private JumpScript jumpgrav;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        jumpgrav = FindObjectOfType<JumpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IUsable.Use()
    {
        if (player.OnLadder)
        {
            //Stop Climbing
            UseLadder(false, 1.5f);
        }
        else
        {
            //Start Climbing
            UseLadder(true, 0);
        }

    }

    private void UseLadder(bool onLadder, float gravity)
    {
        player.OnLadder = onLadder;
        player.myRb.gravityScale = gravity;
        jumpgrav.rb.gravityScale = gravity;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UseLadder(false, 1.5f);
        }
    }
}
