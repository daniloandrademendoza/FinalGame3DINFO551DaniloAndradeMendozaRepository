using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stew : Food {
    public override void Start()
    {
        this.lifePointsFood = 20;
        this.lifePointsNeeded = 80;
    }
    public void IncreaseSize(Collision collision)
    {
        collision.transform.localScale = new Vector3(5f, 5f, 5f);
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreaseSize(collision);
            this.gameObject.SetActive(false);
        }
    }
}
