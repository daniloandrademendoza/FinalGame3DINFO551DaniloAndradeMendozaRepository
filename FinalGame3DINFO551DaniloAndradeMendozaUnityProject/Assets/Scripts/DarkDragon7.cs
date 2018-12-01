using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon7 : Dragon {
    public override void Update()
    {
        if (PersistentData.singleton.lifePointsDarkDragon7 == 0)
        {
            StartCoroutine(this.DieThenDisappearDarkDragon(this.dieWaitTime));
        }
        else
        {
            StartCoroutine(WaitAndAttack(this.waitTime));
        }
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("atk01");
        this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, this.zNewBoxCollider);
    }
    public IEnumerator Wait(float waitTime, Collision collision)
    {
        collision.gameObject.GetComponent<Player>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        collision.gameObject.GetComponent<Player>().enabled = true;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.K)))
        {
            PersistentData.singleton.lifePoints++;
            if (PersistentData.singleton.lifePointsDarkDragon7 > 0)
            {
                PersistentData.singleton.lifePointsDarkDragon7--;
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
            StartCoroutine(Wait(this.waitTime, collision));
        }
    }
}
