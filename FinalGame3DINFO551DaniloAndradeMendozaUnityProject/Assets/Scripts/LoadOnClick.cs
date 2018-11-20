using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {
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
        else if (level == 2)
        {
            SceneManager.LoadScene("Game");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Controls");
        }
    }
}
