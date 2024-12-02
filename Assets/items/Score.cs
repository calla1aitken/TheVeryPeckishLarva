using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    //Score over all levels
    static int score;
    //Score for that level
    int levelscore = 0;

    public TMP_Text messageText;
    string scoreText;
    TMP_Text textMesh;
    // Start is called before the first frame update
    void Start()
    {
        //Prints current score on scene load
        textMesh = GetComponent<TextMeshProUGUI>();
        scoreText = "Score: " + score.ToString();
        textMesh.text = scoreText;
    }

    //Checks level score compared to the level number and moves to next level if all fruit is collected
    public void checkScore()
    {
        levelscore++;
        Debug.Log("The current score for this level is" + levelscore);
        if (SceneManager.GetActiveScene().name == "Level1" && levelscore == 1)
        {
            Debug.Log("Loading Level 2");
            SceneManager.LoadScene(sceneName: "Level2");
            //Resets level score
            levelscore = 0;

        }
        if (SceneManager.GetActiveScene().name == "Level2" && levelscore == 2)
        {
            Debug.Log("Loading Level 3");
            levelscore = 0;
            SceneManager.LoadScene(sceneName: "Level3");
        }
        if (SceneManager.GetActiveScene().name == "Level3" && levelscore == 3)
        {
            Debug.Log("Loading End Screen");
            levelscore = 0;
            
            //Takes total score and gives appropriate end screen
            if (score == 6)
            {
                SceneManager.LoadScene(sceneName: "End3");
            }
            else if (score >= 3)
            {
                SceneManager.LoadScene(sceneName: "End2");
            }
            else
            {
                SceneManager.LoadScene(sceneName: "End1");
            }
            ClearScore();
        }
    }

    public int getScore()
    {
        return score;
    }

    //Adds to score and updates text
    public int AddScore()
    {
        score++;
        scoreText = "Score: "+score.ToString();
        textMesh.text = scoreText;
        return score;
    }

    public int ClearScore()
    {
        score = 0;
        return score;
    }
}
