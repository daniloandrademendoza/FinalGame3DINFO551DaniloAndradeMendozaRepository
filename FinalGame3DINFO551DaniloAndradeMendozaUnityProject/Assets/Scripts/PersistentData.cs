using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour {
    public static PersistentData singleton;
    public int lifePoints = 100;
    public int punch = 0;
    public int kick = 0;
    private void Awake()
    {
        if(singleton==null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
