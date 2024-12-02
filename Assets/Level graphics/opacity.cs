using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.U2D;

//Changes opacity of square based on time passed
public class opacity : MonoBehaviour
{
    float timer;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //Sets timer and default opacity at the start of the scene
        timer = 30f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0, 0, 0, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        //Changes opacity in intervals of 3 seconds
        timer -= Time.deltaTime;

        if (Math.Round(timer) == 3)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.9f);
        }

        if (Math.Round(timer) == 6)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.8f);
        }

        if (Math.Round(timer) == 9)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.7f);
        }

        if (Math.Round(timer) == 12)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.6f);
        }
        if (Math.Round(timer) == 15)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.5f);
        }
        if (Math.Round(timer) == 18)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.4f);
        }
        if (Math.Round(timer) == 21)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.3f);
        }
        if (Math.Round(timer) == 24)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.2f);
        }
        if (Math.Round(timer) == 27)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0.1f);
        }
    }
}
