using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadOnClick : MonoBehaviour {
    public void LoadScene(int level)
    {
        if(level == 0)
        {
            Application.Quit();
        }
        else if(level==1)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (level == 2)
        {
            if (PersistentData.singleton.lifePointsDarkDragon1!=0||PersistentData.singleton.lifePointsDarkDragon2!=0||PersistentData.singleton.lifePointsDarkDragon3!=0||PersistentData.singleton.lifePointsDarkDragon4!=0||PersistentData.singleton.lifePointsDarkDragon5!=0||PersistentData.singleton.lifePointsDarkDragon6!=0||PersistentData.singleton.lifePointsDarkDragon7!=0||PersistentData.singleton.lifePointsDarkDragon8!=0||PersistentData.singleton.lifePointsDarkDragon9!=0||PersistentData.singleton.lifePointsDarkDragon10!=0)
            {
                SceneManager.LoadScene("Game");
            }
            else if (PersistentData.singleton.lifePointsDarkDragon1 == 0 && PersistentData.singleton.lifePointsDarkDragon2 == 0 && PersistentData.singleton.lifePointsDarkDragon3 == 0 && PersistentData.singleton.lifePointsDarkDragon4 == 0 && PersistentData.singleton.lifePointsDarkDragon5 == 0 && PersistentData.singleton.lifePointsDarkDragon6 == 0 && PersistentData.singleton.lifePointsDarkDragon7 == 0 && PersistentData.singleton.lifePointsDarkDragon8 == 0 && PersistentData.singleton.lifePointsDarkDragon9 == 0 && PersistentData.singleton.lifePointsDarkDragon10 == 0)
            {
                SceneManager.LoadScene("Game2");
            }
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Controls");
        }
        }
    }

