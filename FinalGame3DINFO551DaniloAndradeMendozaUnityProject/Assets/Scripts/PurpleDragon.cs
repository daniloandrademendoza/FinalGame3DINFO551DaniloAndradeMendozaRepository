﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleDragon : Dragon{
    public Text lifePointsDragonText;
    public override void Update()
    {
        StartCoroutine(WaitAndAttack(this.waitTime));
        lifePointsDragonText.text = this.lifePoints.ToString();
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("Fly Flame Attack");
        this.boxColliderDragon.center = new Vector3(0f, 10f, -2f);
        this.boxColliderDragon.size = new Vector3(21f, 12f, 12f);
    }
    public void GoDown(Collision collision)
    {
        collision.transform.position = new Vector3(collision.transform.position.x, -10f, collision.transform.position.z);
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch") || collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
            if (this.lifePoints == 0)
            {
                StartCoroutine(this.DieThenDisappearFourDragons(this.dieWaitTime));
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            GoDown(collision);
        }
    }
}
