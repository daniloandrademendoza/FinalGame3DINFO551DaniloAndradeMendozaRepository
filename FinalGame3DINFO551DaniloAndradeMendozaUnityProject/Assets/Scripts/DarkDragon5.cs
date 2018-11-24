﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon5 : Dragon {
    public override void Update()
    {
        this.coroutine = WaitAndAttack(this.waitTime);
        StartCoroutine(this.coroutine);
        if (!this.animatorMonster.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, this.zStartBoxCollider);
        }
        
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("idle");
      this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, 2f);
    }
    public void AffectSkills(Collision collision)
    {
        if (collision.gameObject.GetComponent<Animation>().IsPlaying("punch"))
        {
            collision.gameObject.GetComponent<Player>().punch--;
            Debug.Log("punch");
            Debug.Log(collision.gameObject.GetComponent<Player>().punch);
        }
        else if (collision.gameObject.GetComponent<Animation>().IsPlaying("kick"))
        {
            collision.gameObject.GetComponent<Player>().kick--;
            Debug.Log("kick");
            Debug.Log(collision.gameObject.GetComponent<Player>().kick);
        }
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch") || collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
            Debug.Log("kick");
            Debug.Log(collision.gameObject.GetComponent<Player>().kick);
            Debug.Log("punch");
            Debug.Log(collision.gameObject.GetComponent<Player>().punch);
            AffectSkills(collision);
            if (this.lifePoints == 0)
            {
                this.animatorMonster.Play("die");
                this.gameObject.SetActive(false);
               
            }

        }

    }
}
