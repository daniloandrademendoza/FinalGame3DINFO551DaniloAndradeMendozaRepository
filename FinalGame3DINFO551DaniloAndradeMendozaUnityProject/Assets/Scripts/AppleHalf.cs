using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHalf : Food {
    public override void Start()
    {
        this.lifePointsFood = 20;
        this.lifePointsNeeded = 80;
    }
    public void IncreasePunchHalf()
    {
        PersistentData.singleton.punch += 10;
    }
    public override void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreasePunchHalf();
            this.gameObject.SetActive(false);
        }
    }
}
