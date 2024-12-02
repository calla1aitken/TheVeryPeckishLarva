using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class fallingPlatform : MonoBehaviour
{
    //Rigidbody is set to be asleep in game, on player collsion, the rigidbody wakes up and the platform falls
    public Rigidbody2D Rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "character")
        {
            Debug.Log("Fallen platform");
            Rb.WakeUp();
        }
    }

}
