using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonClick : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(startScreen);
    }

    public void startScreen()
    {
        SceneManager.LoadScene(sceneName: "Level1");
    }
}
