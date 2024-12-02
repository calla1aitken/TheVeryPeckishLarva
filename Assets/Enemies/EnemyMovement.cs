using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Two game objects assigned to array for the enemy to move between
    public Transform[] patrolPoints;
    public int patrolDestination;
    public float moveSpeed;
    
    public Transform player;
    public LayerMask playerLayer;
    public bool playerCheck = false;

    // Update is called once per frame
    void Update()
    {
        if (patrolDestination == 0 && (transform.position.x < patrolPoints[0].position.x))
        {
            transform.localScale = new Vector3(1, 1, 1);
            //Raycast facing the direction the enemy is facing, if enemy spots the player, playerCheck is true
            playerCheck = Physics2D.Raycast(transform.position, Vector2.right, 200, playerLayer);
            
            if (playerCheck)
            {
                //Speeds up when player is spotted
                Debug.Log("Enemy Spotted Player");
                transform.position += Vector3.right * (moveSpeed * 3) * Time.deltaTime;
            }

            else if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                //Changes direction enemy is moving
                patrolDestination = 1;
                
            }
            else
            {
                //Moves towards the current destination
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            }
        }

        //Same functions as previous, but reversed for other patrol point
        if (patrolDestination == 1 && (transform.position.x > patrolPoints[1].position.x))
        {
            transform.localScale = new Vector3(-1, 1, 1);
  
            playerCheck = Physics2D.Raycast(transform.position, Vector2.left, 200, playerLayer);
            

            if (playerCheck)
            {
                Debug.Log("Enemy Spotted Player");
                transform.position += Vector3.left * (moveSpeed * 5) * Time.deltaTime;
            }
            else if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                
                patrolDestination = 0;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            }
        }

    }
}


