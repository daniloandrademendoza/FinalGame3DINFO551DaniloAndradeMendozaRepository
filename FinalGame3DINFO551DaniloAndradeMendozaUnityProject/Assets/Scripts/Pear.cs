using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : Fruit {
    public override void Start()
    {
        this.lifePointsFood = 30;
        this.lifePointsNeeded = 70;
    }
    public void IncreaseJump(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().jumpForce = 5f;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && PersistentData.singleton.lifePoints <= this.lifePointsNeeded)
        {
            PersistentData.singleton.lifePoints = PersistentData.singleton.lifePoints + this.lifePointsFood;
            IncreaseJump(collision);
            this.gameObject.SetActive(false);
        }
    }
}
