using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fruit {
    public override void Start()
    {
        this.lifePointsFood = 4;
        this.lifePointsNeeded = 96;
    }
    public void IncreaseKick(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().kick += 4;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX" && player1.lifePoints <= this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            IncreaseKick(collision);
            this.gameObject.SetActive(false);
        }
    }
}
