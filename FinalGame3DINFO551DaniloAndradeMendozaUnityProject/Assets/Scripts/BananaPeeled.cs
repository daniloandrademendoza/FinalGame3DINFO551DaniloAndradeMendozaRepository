using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeeled : Fruit {
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
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX" && player1.lifePoints <= this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            GrowSize(collision);
            this.gameObject.SetActive(false);
        }
    }
}
