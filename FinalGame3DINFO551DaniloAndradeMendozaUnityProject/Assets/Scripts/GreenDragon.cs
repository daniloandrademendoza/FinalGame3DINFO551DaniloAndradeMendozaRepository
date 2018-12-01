using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenDragon : Dragon {
    public override void Update()
    {
        if (PersistentData.singleton.lifePointsGreenDragon == 0)
        {
            StartCoroutine(this.DieThenDisappearFourDragons(this.dieWaitTime));
        }
        else
        {
            StartCoroutine(WaitAndAttack(this.waitTime));
        }
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("Flame Attack");
        this.boxColliderDragon.center = new Vector3(0f, 0f, -2f);
        this.boxColliderDragon.size = new Vector3(9f, 12f, 12.5f);
    }
   public void Tower(Collision collision)
    {
        collision.transform.position = new Vector3(23.6f, 0f, 135.7f);
        collision.transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.K)))
        {
            PersistentData.singleton.lifePoints++;
            if (PersistentData.singleton.lifePointsGreenDragon > 0)
            {
                PersistentData.singleton.lifePointsGreenDragon--;
            }
            
            if (Input.GetKey(KeyCode.P))
            {
                PersistentData.singleton.punch = PersistentData.singleton.punch + 1;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                PersistentData.singleton.kick = PersistentData.singleton.kick + 1;
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            Tower(collision);
        }
    }
}
