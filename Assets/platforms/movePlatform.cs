using System;
using Unity.VisualScripting;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    Boolean playerImpact;

    private void Start()
    {
        //Sets the platforms spawn position to be that of patrol point
        transform.position = patrolPoints[0].position;
    }

    private void Update()
    {
        //After the player first collides with the platform, the platform starts moving and never stops
        if (playerImpact == true)
        {
            move();
        }
    }

    //Moves platform between two points
    public void move()
    {
        Debug.Log("Platform moving");
        if (patrolDestination == 0 && (transform.position.x <= patrolPoints[0].position.x))
        {
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                patrolDestination = 1;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            }
        }

        if (patrolDestination == 1 && (transform.position.x > patrolPoints[1].position.x))
        {
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                patrolDestination = 0;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            }
        }
    }

    //checks if player is on platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "character")
        {
            playerImpact = true;
        }
    }
}
