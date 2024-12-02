using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public healthplayer playerHealth;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "character")
        {
            Debug.Log("Player Killed");
            playerHealth.takeDamage();
        }
    }


}
