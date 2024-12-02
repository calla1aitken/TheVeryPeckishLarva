using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthplayer : MonoBehaviour
{
    public movement player;
    public int health = 2;

    //Returns player to spawn point if they die
    public void takeDamage()
    {
        Debug.Log("Player Died");
        player.defaultPos();
    }
}
