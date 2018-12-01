using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedDragon : Dragon {
    public override void Update()
    {
        if (PersistentData.singleton.lifePointsRedDragon == 0)
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
        this.animatorMonster.Play("Claw Attack");
        this.boxColliderDragon.center = new Vector3(0f, 0f, -0.5f);
    }
   public void TakeOffLifePoints(Collision collision)
    {
        PersistentData.singleton.lifePoints -= 5;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.K)))
        {
            PersistentData.singleton.lifePoints++;
            if (PersistentData.singleton.lifePointsRedDragon > 0)
            {
                PersistentData.singleton.lifePointsRedDragon--;
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
            TakeOffLifePoints(collision);
        }
    }

}
