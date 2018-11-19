using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryHalf : Fruit {
    public override void Start()
    {
        this.lifePointsFood = 2;
        this.lifePointsNeeded = 98;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX" && player1.lifePoints <= this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            this.gameObject.SetActive(false);
        }
    }
}
