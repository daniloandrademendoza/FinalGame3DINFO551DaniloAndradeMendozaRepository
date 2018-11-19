using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour {
    public GameObject player1;
    public Player player2;
	void Start () {
        RestoreGame();

    }
    void RestoreGame()
    {
        string 
            p = PlayerPrefs.GetString("PlayerLocation");
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
                player2.kick = playerPoints.kick;
                player2.punch = playerPoints.punch;
                player2.lifePoints = playerPoints.lifePoints;
                Debug.Log(player2.punch);

            }
        }
    }
	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
	}
    void SaveGame()
    {
        SavePosition s = new SavePosition();
        s.x = player1.transform.position.x;
        s.y = player1.transform.position.y;
        s.z = player1.transform.position.z;
        s.kick = player2.kick;
        s.punch = player2.punch;
        s.lifePoints = player2.lifePoints;
        string json = JsonUtility.ToJson(s);
        Debug.Log(json);
        PlayerPrefs.SetString("PlayerLocation", json);
    }
}
