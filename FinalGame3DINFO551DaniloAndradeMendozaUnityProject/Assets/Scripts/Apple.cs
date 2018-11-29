using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Food {
	public override void Start () {
        this.lifePointsFood = 40;
        this.lifePointsNeeded = 60;
    }
    public void IncreasePunch()
    {
        PersistentData.singleton.punch += 20;
    }
	public override void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.name == "MAX"&&PersistentData.singleton.lifePoints<=this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreasePunch();
            this.gameObject.SetActive(false);
        }
	}
}
