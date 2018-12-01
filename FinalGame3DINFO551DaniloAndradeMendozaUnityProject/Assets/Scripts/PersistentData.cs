using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour {
    public static PersistentData singleton;
    public int lifePoints = 100;
    public int punch = 0;
    public int kick = 0;
    public int lifePointsDarkDragon1=10;
    public int lifePointsDarkDragon2=10;
    public int lifePointsDarkDragon3=10;
    public int lifePointsDarkDragon4=10;
    public int lifePointsDarkDragon5=10;
    public int lifePointsDarkDragon6=10;
    public int lifePointsDarkDragon7=10;
    public int lifePointsDarkDragon8=10;
    public int lifePointsDarkDragon9=10;
    public int lifePointsDarkDragon10=10;
    public int lifePointsBlueDragon=10;
    public int lifePointsRedDragon=10;
    public int lifePointsGreenDragon=10;
    public int lifePointsPurpleDragon=10;
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
