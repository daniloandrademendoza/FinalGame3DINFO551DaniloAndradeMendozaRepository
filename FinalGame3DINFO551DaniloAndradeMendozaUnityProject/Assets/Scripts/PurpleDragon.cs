using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleDragon : Dragon{
    public override void Update()
    { 
        if (PersistentData.singleton.lifePointsPurpleDragon == 0)
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
        if (collision.gameObject.name == "MAX" && (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.K)))
        {
            PersistentData.singleton.lifePoints++;
            if (PersistentData.singleton.lifePointsPurpleDragon > 0)
            {
                PersistentData.singleton.lifePointsPurpleDragon--;
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
            GoDown(collision);
        }
    }
}
