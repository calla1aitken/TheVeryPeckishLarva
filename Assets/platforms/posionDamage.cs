using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posionDamage : MonoBehaviour
{
    public healthplayer player;
    Boolean playerImpact;
    float timer = 1.5f;

    void Update()
    {
        //While player is touching the poision a timer will count down
        //If timer ends, player dies
        if (playerImpact == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Debug.Log("Player Died from Posion");
                player.takeDamage();
            }
        }

        //Timer resets after player leaves poison
        if (playerImpact == false)
        {
            timer = 1.5f;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "character")
        {
            Debug.Log("Touching Poison");
            playerImpact = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
            Debug.Log("Not Touching Poison");
            playerImpact = false;
    }

}
