using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text lifePointsText;
    public Text punchText;
    public Text kickText;

    public void Start()
    {
        lifePointsText.text = PersistentData.singleton.lifePoints.ToString();
        punchText.text = PersistentData.singleton.punch.ToString();
        kickText.text = PersistentData.singleton.kick.ToString();


    }
}
