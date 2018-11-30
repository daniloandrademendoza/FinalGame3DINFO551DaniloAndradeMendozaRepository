using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {
    private string sceneChecker;
    private void Start()
    {
        sceneChecker = "Game";
    }
    public void LoadScene(int level)
    {
        if(level==0)
        {
            Application.Quit();
        }
        else if(level==1)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (level == 2&&sceneChecker=="Game")
        {
            SceneManager.LoadScene("Game");
            sceneChecker = "Game";
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Controls");
        }
        else if (level ==4&&sceneChecker=="Game2")
        {
            SceneManager.LoadScene("Game2");
            sceneChecker = "Game2";
        }
    }
}
