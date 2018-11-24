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
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX" && player1.lifePoints <= this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            GrowSizeHalf(collision);
            this.gameObject.SetActive(false);
        }
    }
}
