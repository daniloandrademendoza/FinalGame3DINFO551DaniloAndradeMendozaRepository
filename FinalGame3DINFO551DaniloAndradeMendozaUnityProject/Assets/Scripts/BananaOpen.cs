using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaOpen : Fruit {

    public override void Start()
    {
        this.lifePointsFood = 25;
        this.lifePointsNeeded = 75;
    }
    public void GrowSizeHalf(Collision collision)
    {
        collision.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public override void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            GrowSizeHalf(collision);
            this.gameObject.SetActive(false);
        }
    }
}
