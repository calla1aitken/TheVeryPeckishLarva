using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class movement : MonoBehaviour
{
    Vector3 defaultpos;

    public healthplayer health;
    public Rigidbody2D Rb;
    
    //Gets layers of different kinds of platforms
    public LayerMask groundLayer;
    public LayerMask platformLayer;
    public LayerMask movingPlatformLayer;
    public LayerMask poisonLayer;
    public LayerMask rotatingPlatformLayer;

    public movePlatform movePlatform;

    public bool onGround = false;
    public bool onPlatform = false;
    public bool onMovingPlatform = false;
    public bool onPoison = false;
    public bool onRotatingPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        defaultpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks which surface player is on
        onGround = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);
        onPlatform = Physics2D.Raycast(transform.position, Vector2.down, 1, platformLayer);
        onMovingPlatform = Physics2D.Raycast(transform.position, Vector2.down, 1, movingPlatformLayer);
        onPoison = Physics2D.Raycast(transform.position, Vector2.down, 1, poisonLayer);
        onRotatingPlatform = Physics2D.Raycast(transform.position, Vector2.down, 1, rotatingPlatformLayer);

        //Inputs 
        bool space = Input.GetKey(KeyCode.Space);
        bool rightKey = Input.GetKey(KeyCode.RightArrow);
        bool leftKey = Input.GetKey(KeyCode.LeftArrow);

        if (rightKey)
        {
            Debug.Log("Right Key Pressed");
            transform.localScale = new Vector3(1, 1, 1);
            Rb.AddForce(Vector2.right, ForceMode2D.Impulse);
        }

        if (leftKey)
        {
            Debug.Log("Left Key Pressed");
            transform.localScale = new Vector3(-1, 1, 1);
            Rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        }

        if (space && onGround || space && onPlatform || space && onRotatingPlatform || space && onPoison || space && onMovingPlatform)
        {
            Debug.Log("Space Key Pressed");
            Rb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
        }


    }
    //Returns player to spawn point
    public void defaultPos()
    {
        transform.position = defaultpos;
    }

    //Kills player if they leave the screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundaries")
        {
            Debug.Log("Player left Level Boundaries");
            defaultPos();
        }
    }



}
