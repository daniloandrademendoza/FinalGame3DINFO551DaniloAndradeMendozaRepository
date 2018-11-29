using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiSlice : Food {
    public override void Start()
    {
        this.lifePointsFood = 4;
        this.lifePointsNeeded = 96;
    }
    public void IncreaseRunSlice(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().playerSpeedRun = 12.5f;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreaseRunSlice(collision);
            this.gameObject.SetActive(false);
        }
    }
}
