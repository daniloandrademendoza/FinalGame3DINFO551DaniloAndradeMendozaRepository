﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHalf : Fruit {
    public override void Start()
    {
        this.lifePointsFood = 20;
        this.lifePointsNeeded = 80;
    }
    public void IncreasePunchHalf(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().punch += 10;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        Player player1 = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.name == "MAX" && player1.lifePoints <= this.lifePointsNeeded)
        {
            player1.lifePoints = player1.lifePoints + this.lifePointsFood;
            IncreasePunchHalf(collision);
            this.gameObject.SetActive(false);
        }
    }
}
