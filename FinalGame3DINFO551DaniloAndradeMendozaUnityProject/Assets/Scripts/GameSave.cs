using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSave : MonoBehaviour {
    public GameObject player1;
    public Text lifePointsText;
    public Text punchText;
    public Text kickText;
    public Text lifePointsDarkDragon1Text;
    public Text lifePointsDarkDragon2Text;
    public Text lifePointsDarkDragon3Text;
    public Text lifePointsDarkDragon4Text;
    public Text lifePointsDarkDragon5Text;
    public Text lifePointsDarkDragon6Text;
    public Text lifePointsDarkDragon7Text;
    public Text lifePointsDarkDragon8Text;
    public Text lifePointsDarkDragon9Text;
    public Text lifePointsDarkDragon10Text;
    public Text lifePointsBlueDragonText;
    public Text lifePointsRedDragonText;
    public Text lifePointsGreenDragonText;
    public Text lifePointsPurpleDragonText;
    void Start () {
        RestoreGame();
    }
    void FixedUpdate()
    { 
        lifePointsText.text = PersistentData.singleton.lifePoints.ToString();
        punchText.text = PersistentData.singleton.punch.ToString();
        kickText.text = PersistentData.singleton.kick.ToString();
        lifePointsDarkDragon1Text.text = PersistentData.singleton.lifePointsDarkDragon1.ToString();
        lifePointsDarkDragon2Text.text = PersistentData.singleton.lifePointsDarkDragon2.ToString();
        lifePointsDarkDragon3Text.text = PersistentData.singleton.lifePointsDarkDragon3.ToString();
        lifePointsDarkDragon4Text.text = PersistentData.singleton.lifePointsDarkDragon4.ToString();
        lifePointsDarkDragon5Text.text = PersistentData.singleton.lifePointsDarkDragon5.ToString();
        lifePointsDarkDragon6Text.text = PersistentData.singleton.lifePointsDarkDragon6.ToString();
        lifePointsDarkDragon7Text.text = PersistentData.singleton.lifePointsDarkDragon7.ToString();
        lifePointsDarkDragon8Text.text = PersistentData.singleton.lifePointsDarkDragon8.ToString();
        lifePointsDarkDragon9Text.text = PersistentData.singleton.lifePointsDarkDragon9.ToString();
        lifePointsDarkDragon10Text.text = PersistentData.singleton.lifePointsDarkDragon10.ToString();
        lifePointsBlueDragonText.text = PersistentData.singleton.lifePointsBlueDragon.ToString();
        lifePointsRedDragonText.text = PersistentData.singleton.lifePointsRedDragon.ToString();
        lifePointsGreenDragonText.text = PersistentData.singleton.lifePointsGreenDragon.ToString();
        lifePointsPurpleDragonText.text = PersistentData.singleton.lifePointsPurpleDragon.ToString();
}
    void RestoreGame()
    {
    
        string p = PlayerPrefs.GetString("PlayerLocation");
        if(p!=null && p.Length >0)
        {
            SavePosition s = JsonUtility.FromJson<SavePosition>(p);
            if(s!=null)
            {
                Vector3 position = new Vector3();
                position.x = s.x;
                position.y = s.y;
                position.z = s.z;
                player1.transform.position = position;
                SavePosition playerPoints = new SavePosition();
                playerPoints.kick = s.kick;
                playerPoints.punch = s.punch;
                playerPoints.lifePoints = s.lifePoints;
                playerPoints.yRotation = s.yRotation;
                playerPoints.lifePointsDarkDragon1 = s.lifePointsDarkDragon1;
                playerPoints.lifePointsDarkDragon2 = s.lifePointsDarkDragon2;
                playerPoints.lifePointsDarkDragon3 = s.lifePointsDarkDragon3;
                playerPoints.lifePointsDarkDragon4 = s.lifePointsDarkDragon4;
                playerPoints.lifePointsDarkDragon5 = s.lifePointsDarkDragon5;
                playerPoints.lifePointsDarkDragon6 = s.lifePointsDarkDragon6;
                playerPoints.lifePointsDarkDragon7 = s.lifePointsDarkDragon7;
                playerPoints.lifePointsDarkDragon8 = s.lifePointsDarkDragon8;
                playerPoints.lifePointsDarkDragon9 = s.lifePointsDarkDragon9;
                playerPoints.lifePointsDarkDragon10 = s.lifePointsDarkDragon10;
                playerPoints.lifePointsBlueDragon = s.lifePointsBlueDragon;
                playerPoints.lifePointsRedDragon = s.lifePointsRedDragon;
                playerPoints.lifePointsGreenDragon = s.lifePointsGreenDragon;
                playerPoints.lifePointsPurpleDragon = s.lifePointsPurpleDragon;
                player1.transform.eulerAngles = new Vector3(0f, playerPoints.yRotation, 0f);
                PersistentData.singleton.kick = playerPoints.kick;
                PersistentData.singleton.punch = playerPoints.punch;
                PersistentData.singleton.lifePoints = playerPoints.lifePoints;
                PersistentData.singleton.lifePointsDarkDragon1 = playerPoints.lifePointsDarkDragon1;
                PersistentData.singleton.lifePointsDarkDragon2 = playerPoints.lifePointsDarkDragon2;
                PersistentData.singleton.lifePointsDarkDragon3 = playerPoints.lifePointsDarkDragon3;
                PersistentData.singleton.lifePointsDarkDragon4 = playerPoints.lifePointsDarkDragon4;
                PersistentData.singleton.lifePointsDarkDragon5 = playerPoints.lifePointsDarkDragon5;
                PersistentData.singleton.lifePointsDarkDragon6 = playerPoints.lifePointsDarkDragon6;
                PersistentData.singleton.lifePointsDarkDragon7 = playerPoints.lifePointsDarkDragon7;
                PersistentData.singleton.lifePointsDarkDragon8 = playerPoints.lifePointsDarkDragon8;
                PersistentData.singleton.lifePointsDarkDragon9 = playerPoints.lifePointsDarkDragon9;
                PersistentData.singleton.lifePointsDarkDragon10 = playerPoints.lifePointsDarkDragon10;
                PersistentData.singleton.lifePointsBlueDragon = playerPoints.lifePointsBlueDragon;
                PersistentData.singleton.lifePointsRedDragon = playerPoints.lifePointsRedDragon;
                PersistentData.singleton.lifePointsGreenDragon = playerPoints.lifePointsGreenDragon;
                PersistentData.singleton.lifePointsPurpleDragon = playerPoints.lifePointsPurpleDragon;
                if(player1.gameObject.GetComponent<Player>().dragons.Length==10)
                {
                    if (PersistentData.singleton.lifePointsDarkDragon1 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[0].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon2 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[1].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon3 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[2].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon4 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[3].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon5 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[4].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon6 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[5].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon7 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[6].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon8 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[7].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon9 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[8].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsDarkDragon10 != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[9].SetActive(true);
                    }
                }
                else if(player1.gameObject.GetComponent<Player>().dragons.Length == 4)
                {
                    if (PersistentData.singleton.lifePointsBlueDragon != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[0].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsRedDragon != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[1].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsGreenDragon != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[2].SetActive(true);
                    }
                    if (PersistentData.singleton.lifePointsPurpleDragon != 0)
                    {
                        player1.gameObject.GetComponent<Player>().dragons[3].SetActive(true);
                    }
                }
                
            }
        }
    }
	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            UnsaveGame();
        }
        else if(Input.GetKeyDown(KeyCode.G))
        {
            RestoreGame();
        }
    }
    void SaveGame()
    {
        SavePosition s = new SavePosition();
        s.x = player1.transform.position.x;
        s.y = player1.transform.position.y;
        s.z = player1.transform.position.z;
        s.yRotation = player1.transform.eulerAngles.y;
        s.kick = PersistentData.singleton.kick;
        s.punch = PersistentData.singleton.punch;
        s.lifePoints = PersistentData.singleton.lifePoints;
        s.lifePointsDarkDragon1 = PersistentData.singleton.lifePointsDarkDragon1;
        s.lifePointsDarkDragon2 = PersistentData.singleton.lifePointsDarkDragon2;
        s.lifePointsDarkDragon3 = PersistentData.singleton.lifePointsDarkDragon3;
        s.lifePointsDarkDragon4 = PersistentData.singleton.lifePointsDarkDragon4;
        s.lifePointsDarkDragon5 = PersistentData.singleton.lifePointsDarkDragon5;
        s.lifePointsDarkDragon6 = PersistentData.singleton.lifePointsDarkDragon6;
        s.lifePointsDarkDragon7 = PersistentData.singleton.lifePointsDarkDragon7;
        s.lifePointsDarkDragon8 = PersistentData.singleton.lifePointsDarkDragon8;
        s.lifePointsDarkDragon9 = PersistentData.singleton.lifePointsDarkDragon9;
        s.lifePointsDarkDragon10 = PersistentData.singleton.lifePointsDarkDragon10;
        s.lifePointsBlueDragon = PersistentData.singleton.lifePointsBlueDragon;
        s.lifePointsRedDragon = PersistentData.singleton.lifePointsRedDragon;
        s.lifePointsGreenDragon = PersistentData.singleton.lifePointsGreenDragon;
        s.lifePointsPurpleDragon = PersistentData.singleton.lifePointsPurpleDragon;
        string json = JsonUtility.ToJson(s);
        Debug.Log(json);
        PlayerPrefs.SetString("PlayerLocation", json);
    }
    void UnsaveGame()
    {
        SavePosition s = new SavePosition();
        s.x = 10.24219f;
        s.y = 0f;
        s.yRotation = -1.927f;
        s.z = -6.04727f;
        s.kick = 0;
        s.punch = 0;
        s.lifePoints = 100;
        s.lifePointsDarkDragon1 = 10;
        s.lifePointsDarkDragon2 = 10;
        s.lifePointsDarkDragon3 = 10;
        s.lifePointsDarkDragon4 = 10;
        s.lifePointsDarkDragon5 = 10;
        s.lifePointsDarkDragon6 = 10;
        s.lifePointsDarkDragon7 = 10;
        s.lifePointsDarkDragon8 = 10;
        s.lifePointsDarkDragon9 = 10;
        s.lifePointsDarkDragon10 = 10;
        s.lifePointsBlueDragon = 10;
        s.lifePointsRedDragon = 10;
        s.lifePointsGreenDragon = 10;
        s.lifePointsPurpleDragon = 10;
        for (int i=0; i<player1.gameObject.GetComponent<Player>().dragons.Length;i++)
        {
            player1.gameObject.GetComponent<Player>().dragons[i].SetActive(true);
        }
        string json = JsonUtility.ToJson(s);
        Debug.Log(json);
        PlayerPrefs.SetString("PlayerLocation", json);
    }

   
}
