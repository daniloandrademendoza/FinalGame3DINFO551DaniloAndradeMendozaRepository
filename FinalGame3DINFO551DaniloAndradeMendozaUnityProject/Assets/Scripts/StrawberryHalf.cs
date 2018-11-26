using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryHalf : Fruit {
    public override void Start()
    {
        this.lifePointsFood = 2;
        this.lifePointsNeeded = 98;
    }
    public void IncreaseKickHalf()
    {
        PersistentData.singleton.kick += 2;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreaseKickHalf();
            this.gameObject.SetActive(false);
        }
    }
}
