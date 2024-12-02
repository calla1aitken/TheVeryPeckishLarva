using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine.UI;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
//Timer For each level
public class Timer : MonoBehaviour
{
    float timer;
    public TMP_Text messageText;
    string timerText;
    TMP_Text textMesh;
    public Score score;
    int finalScore;

    void Start()
    {
        //Resets time at start of level
        timer = 30f;
        Debug.Log("Level started");
        textMesh = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Updates timer text in the level
        timerText = "Time: " + Math.Round(timer).ToString();
        textMesh.text = timerText;

        if (timer <= 0)
        {
            timerEnded();
        }

        
    }
    //Decides which scene will start next after the timer ends
    void timerEnded()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene(sceneName:"Level2");
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene(sceneName: "Level3");
        }

        //After level 3, the game is over and the player gets an end screen based on their total score
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            finalScore = score.getScore();
            if (finalScore == 6)
            {
                SceneManager.LoadScene(sceneName: "End3");
            }
            else if (finalScore >= 3)
            {
                SceneManager.LoadScene(sceneName: "End2");
            }
            else
            {
                SceneManager.LoadScene(sceneName: "End1");
            }
        }
    }
}
