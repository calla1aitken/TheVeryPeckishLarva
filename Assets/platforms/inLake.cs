using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inLake : MonoBehaviour
{
    public Rigidbody2D rb;

    //When entering the lake, the players gravity is changed to make them slower
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.mass = 20f;
        rb.drag = 15f;
    }

    //When leaving the laek, the players gravity resets
    private void OnTriggerExit2D(Collider2D collision)
    {
        rb.mass = 10f;
        rb.drag = 5f;
    }



}
