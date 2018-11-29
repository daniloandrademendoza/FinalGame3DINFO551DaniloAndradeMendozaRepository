using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Food {
    public override void Start()
    {
        this.lifePointsFood = 4;
        this.lifePointsNeeded = 96;
    }
    public void IncreaseKick()
    {
        PersistentData.singleton.kick += 4;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreaseKick();
            this.gameObject.SetActive(false);
        }
    }
}
