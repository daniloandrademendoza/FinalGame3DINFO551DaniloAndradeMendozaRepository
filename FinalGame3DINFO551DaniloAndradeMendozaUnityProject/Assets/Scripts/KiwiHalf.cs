using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiHalf : Fruit {
    public override void Start()
    {
        this.lifePointsFood = 10;
        this.lifePointsNeeded = 90;
    }
    public void IncreaseRun(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().playerSpeedRun = 15f;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX" && player1.lifePoints <= this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            IncreaseRun(collision);
            this.gameObject.SetActive(false);
        }
    }
}
