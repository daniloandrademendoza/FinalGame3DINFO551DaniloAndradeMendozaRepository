using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeeled : Food {
    public override void Start()
    {
        this.lifePointsFood = 50;
        this.lifePointsNeeded = 50;
    }
    public void GrowSize(Collision collision)
    {
        collision.gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }
    public override void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            GrowSize(collision);
            this.gameObject.SetActive(false);
        }
    }
}
