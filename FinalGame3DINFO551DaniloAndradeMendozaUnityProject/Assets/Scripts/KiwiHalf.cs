using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiHalf : Food {
    public override void Start()
    {
        this.lifePointsFood = 10;
        this.lifePointsNeeded = 90;
    }
    public void IncreaseRun(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().playerSpeedRun = 15f;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreaseRun(collision);
            this.gameObject.SetActive(false);
        }
    }
}
