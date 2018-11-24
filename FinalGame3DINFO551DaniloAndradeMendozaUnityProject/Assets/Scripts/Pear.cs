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
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX" && player1.lifePoints <= this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            IncreaseJump(collision);
            this.gameObject.SetActive(false);
        }
    }
}
