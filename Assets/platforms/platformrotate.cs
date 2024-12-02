using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class platformrotate : MonoBehaviour
{
    public Transform player;

    public LayerMask platformLayer;
    bool onPlatform = false;

    //Point the platform rotates around
    public Transform target;

    private float timer;
    private float delay = 0.2f;

    void Update()
    {
        //checks if player is on platform
        onPlatform = Physics2D.Raycast(player.position, Vector2.down, 1, platformLayer);
        //If the player is on the platform and the platform is above the lowest point, it will rotate down
        if (onPlatform && this.transform.position.y > 1f)
        {
            //there is a slight delay of the platform starting to rotate after the player lands on it
            //After the timer matches the delay, the platform will start to rotate as soon as the player touches it
            timer += Time.deltaTime;
            if (timer > delay) {
                //Rotates around point
                transform.RotateAround(target.position, Vector3.back, 10 * Time.deltaTime);
            }
        }
    
        //if platform is beneath the highest point and player is not on it, it will rotate back up
        if (this.transform.position.y < 1.6f && this.transform.position.y >= 0.9f && (onPlatform == false))
        {
            Debug.Log(Mathf.Round(this.transform.position.y * 10.0f) * 0.1f);
            transform.RotateAround(target.position, Vector3.forward, 10 * Time.deltaTime);

            //Timer resets after the player leaves the platform long enough for it to return to start position
            if ((Mathf.Round(this.transform.position.y * 10.0f) * 0.1f) == 1.6f)
            {
                timer = 0;
            }
        }
    }
}




