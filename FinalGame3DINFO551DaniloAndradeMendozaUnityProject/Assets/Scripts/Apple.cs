using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Fruit {
	public override void Start () {
        this.lifePointsFood = 40;
        this.lifePointsNeeded = 60;
    }
    public void IncreasePunch(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().punch += 20;
    }
	public override void OnCollisionEnter(Collision collision) {
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX"&&player1.lifePoints<=this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            IncreasePunch(collision);
            this.gameObject.SetActive(false);
        }
	}
}
