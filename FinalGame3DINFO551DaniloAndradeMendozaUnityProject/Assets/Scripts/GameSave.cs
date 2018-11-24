using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class GameSave : MonoBehaviour {
    public GameObject player1;
    void Start () {
        RestoreGame();
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
                player1.GetComponent<Player>().kick = playerPoints.kick;
                player1.GetComponent<Player>().punch = playerPoints.punch;
                player1.GetComponent<Player>().lifePoints = playerPoints.lifePoints;
                player1.transform.eulerAngles = new Vector3(0f,playerPoints.yRotation,0f);
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
        else if(Input.GetKeyDown(KeyCode.R))
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
        s.kick = player1.GetComponent<Player>().kick;
        s.punch = player1.GetComponent<Player>().punch;
        s.lifePoints = player1.GetComponent<Player>().lifePoints;
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
        string json = JsonUtility.ToJson(s);
       // s = JsonUtility.FromJson<SavePosition>(json);
        Debug.Log(json);
        PlayerPrefs.SetString("PlayerLocation", json);
    }
    //public static T UnsaveGame<T>(string xml)
    //{

    //    T obj = default(T);
    //    XmlSerializer serializer = new XmlSerializer(typeof(T));
    //    using (TextReader textReader = new StringReader(xml))
    //    {
    //        obj = (T)serializer.Deserialize(textReader);
    //    }
    //    return obj;
    //}
}
